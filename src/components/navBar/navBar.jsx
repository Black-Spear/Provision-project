import logo from "../../images/Logo_Color.svg";
import GradientButton from "../Buttons/gradientButton";

export default function Navbar() {
  const hamburger = new URL(
    "https://upload.wikimedia.org/wikipedia/commons/thumb/5/59/Hamburger_icon_white.svg/1024px-Hamburger_icon_white.svg.png"
    // ADD THIS FOR A LOCAL FILE: import.meta.url
  ).href;
  return (
    <header className="sticky flex items-center justify-between p-[4vh] px-6">
      <div className=" w-40 ">
        <img src={logo} alt="Provision" />
      </div>
      <nav className="hidden  gap-8 md:flex">
        <a href="" className="   text-white hover:text-primary ">
          Home
        </a>
        <a href="" className="   text-white hover:text-primary">
          Learn
        </a>
        <a href="" className="   text-white hover:text-primary">
          About
        </a>
        <a href="" className="   text-white hover:text-primary">
          Contact
        </a>
      </nav>

      <div className=" hidden items-center md:flex">
        <p className="pr-4 text-white">Log in</p>
        <GradientButton>Sign up</GradientButton>
      </div>
      <div className="w-8 md:hidden">
        <img src={hamburger} alt="navigation links button" />
      </div>
    </header>
  );
}
