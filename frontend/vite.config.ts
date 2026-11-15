import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'
import basicSsl from '@vitejs/plugin-basic-ssl'

export default defineConfig({
  plugins: [react(), basicSsl()],
  server: {
    host: 'localhost',
    port: 5173,
    strictPort: true,
    https: {},
    proxy: {
      '/api': {
        target: 'https://localhost:7443',
        changeOrigin: true,
        // Local ASP.NET development certificate only; production uses trusted TLS.
        secure: false,
      },
    },
  },
})
