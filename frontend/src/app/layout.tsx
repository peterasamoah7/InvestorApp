import type { Metadata } from "next";
import "./globals.css";
import "bootstrap/dist/css/bootstrap.min.css";

export const metadata: Metadata = {
  title: "InvestorApp",
  description: "Simple Investor Portal",
};

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="en">
      <head></head>
      <body>
        <nav className="navbar navbar-expand-lg">
          <div className="container-fluid">
              <div className="collapse navbar-collapse" id="navbarSupportedContent">
                  <ul className="navbar-nav me-auto mb-2 mb-lg-0">
                      <li className="nav-item">
                          <a className="nav-link" aria-current="page" href="/">Home</a>
                      </li>              
                  </ul>            
              </div>
          </div>
        </nav>
        <div className="container">
          {children}
        </div>        
      </body>
    </html>
  );
}
