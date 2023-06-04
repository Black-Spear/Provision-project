import logo from "../../images/Logo_Color.svg";
import GradientButton from "../Buttons/gradientButton";
import SecondButton from "../Buttons/secondegradientButton";
export default function Navbar() {
  return (
    <div className="sticky  flex justify-between items-center ">
      <div className="flex mr-6 w-44       ">
        <img src={logo} alt="Provision" />
      </div>
      <nav className="flex ">
        <a
          href=""
          className="border-b-4   border-transparent mx-6  text-white hover:border-b-primary "
        >
          Home
        </a>
        <a
          href=""
          className="border-b-4 border-transparent mx-6 text-white hover:border-b-primary"
        >
          About
        </a>
        <a
          href=""
          className="border-b-4 border-transparent mx-6 text-white hover:border-b-primary"
        >
          learn
        </a>
        <a
          href=""
          className="border-b-4 border-transparent mx-6 text-white hover:border-b-primary"
        >
          Contact
        </a>
      </nav>

      <div className="flex">
        <SecondButton>Log In</SecondButton>
        <GradientButton>Sign In</GradientButton>
      </div>
    </div>
  );
}
