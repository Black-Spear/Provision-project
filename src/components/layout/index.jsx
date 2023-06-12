import Navbar from "../navBar/navBar";
// eslint-disable-next-line react/prop-types
export default function Layout ({children}) {
  return (
    <div className="container mx-auto ">
      <Navbar />
      {children}
    </div>
  );
}


