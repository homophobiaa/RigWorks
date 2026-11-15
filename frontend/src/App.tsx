import { useEffect, useState } from 'react'
import { motion, useReducedMotion } from 'motion/react'
import { api, refreshCsrfToken } from './services/api/client'
import { motionTokens } from './lib/motion'
import styles from './App.module.css'

type ConnectionState = 'loading' | 'connected' | 'error'

export function App() {
  const [connection, setConnection] = useState<ConnectionState>('loading')
  const [session, setSession] = useState('Checking session…')
  const [attempt, setAttempt] = useState(0)
  const reducedMotion = useReducedMotion()

  useEffect(() => {
    const controller = new AbortController()
    async function initialize() {
      try {
        const options = { signal: controller.signal }
        const [health, currentUser] = await Promise.all([
          api.GET('/api/health', options),
          api.GET('/api/auth/me', options),
          refreshCsrfToken(controller.signal),
        ])
        if (!health.response.ok || !health.data) throw new Error('API unavailable')
        if (currentUser.response.status !== 401 && !currentUser.response.ok) {
          throw new Error('Session unavailable')
        }
        if (controller.signal.aborted) return
        setConnection('connected')
        setSession(currentUser.data ? `Signed in as ${currentUser.data.userName}` : 'Not signed in')
      } catch {
        if (!controller.signal.aborted) {
          setConnection('error')
          setSession('Session unavailable')
        }
      }
    }
    void initialize()
    return () => controller.abort()
  }, [attempt])

  function reconnect() {
    setConnection('loading')
    setSession('Checking session…')
    setAttempt((value) => value + 1)
  }

  return (
    <>
      <header className={styles.header}><span>RigWorks</span></header>
      <main className={styles.main}>
        <p className={styles.eyebrow}>Development preview</p>
        <h1>RigWorks starts here.</h1>
        <p className={styles.intro}>
          A workspace for choosing PC components, understanding compatibility,
          and building with confidence.
        </p>
        <section className={styles.panel} aria-labelledby="connection-title">
          <h2 id="connection-title">Application connection</h2>
          <motion.div
            key={connection}
            initial={{ opacity: reducedMotion ? 1 : 0 }}
            animate={{ opacity: 1 }}
            transition={{ duration: motionTokens.duration.quick, ease: motionTokens.easing.productiveStandard }}
            role="status"
            aria-live="polite"
            aria-atomic="true"
          >
            <p>{connection === 'loading' ? 'Connecting…' : connection === 'connected' ? 'API connected' : 'Unable to connect to the API'}</p>
            <p className={styles.secondary}>{session}</p>
          </motion.div>
          <p className={styles.secondary}>
            {connection === 'error'
              ? 'Start the backend and trust the local HTTPS certificates, then try again.'
              : 'This verifies the application connection. The component catalog and builder are next.'}
          </p>
          <button className={styles.button} onClick={reconnect} disabled={connection === 'loading'}>
            {connection === 'loading' ? 'Checking connection…' : 'Check connection'}
          </button>
        </section>
      </main>
    </>
  )
}
