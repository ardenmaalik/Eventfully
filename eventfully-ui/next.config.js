/** @type {import('next').NextConfig} */
const nextConfig = {
  experimental: {
    appDir: true,
    },
    env: {
        REACT_APP_API_URL: 'https://localhost:7118'
    }
}

module.exports = nextConfig
