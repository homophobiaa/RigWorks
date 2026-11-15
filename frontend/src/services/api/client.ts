import createClient, { type Middleware } from 'openapi-fetch'
import type { paths } from './schema'

export const api = createClient<paths>({ credentials: 'same-origin' })

function readCsrfToken() {
  const cookie = document.cookie.split('; ').find((part) => part.startsWith('XSRF-TOKEN='))
  return cookie ? decodeURIComponent(cookie.substring('XSRF-TOKEN='.length)) : undefined
}

// Also call this after a successful sign-in, registration or sign-out: the
// request token belongs to the identity that was current when it was issued.
export async function refreshCsrfToken(signal?: AbortSignal) {
  const { response } = await api.GET('/api/auth/csrf', { signal })
  if (!response.ok) throw new Error('Could not initialize request protection.')
}

const csrfMiddleware: Middleware = {
  async onRequest({ request }) {
    if (['GET', 'HEAD', 'OPTIONS', 'TRACE'].includes(request.method)) return
    if (!readCsrfToken()) await refreshCsrfToken(request.signal)
    const token = readCsrfToken()
    if (!token) throw new Error('The browser did not accept the request protection cookie.')
    request.headers.set('X-XSRF-TOKEN', token)
  },
}

api.use(csrfMiddleware)
