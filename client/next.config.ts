import type { NextConfig } from "next";

const nextConfig: NextConfig = {
  async redirects() {
    return [
      {
        source: '/',
        destination: '/investors',
        permanent: true,
      },      
    ]
  },
};

export default nextConfig;
