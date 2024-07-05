import { defineConfig, splitVendorChunkPlugin } from 'vite';
import react from '@vitejs/plugin-react-swc';
import EnvironmentPlugin from 'vite-plugin-environment';
import checker from 'vite-plugin-checker';


export default defineConfig({
  plugins: [
    react(),
    splitVendorChunkPlugin(),
    EnvironmentPlugin('all', {
      prefix: 'REACT_APP'
    }),
    checker({
      typescript: true,
      eslint: {
        lintCommand: 'eslint "./src/**/*.{ts,tsx}"', // for example, lint .ts & .tsx
      },
    }),
  ],
  server: {
    host: 'localhost', 
    port: 3000
  },
  build: {
    rollupOptions: {
      output: {
        manualChunks: (id: string) => {
          if (id.includes('a-very-large-dependency')) {
            return 'big-chungus';
          }

          if (id.includes('react-router-dom') || id.includes('react-router')) {
            return '@react-router';
          }
        }
      }
    },
    outDir: 'build',
    sourcemap: false
  },
  logLevel: 'info'
});
