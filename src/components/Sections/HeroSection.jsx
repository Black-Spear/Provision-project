import GradientButton from "../Buttons/gradientButton";
import SecondButton from "../Buttons/secondegradientButton";
// Graphic assets
import CoolGuy from "../../images/RightGraphicCoolGuyCoolGuy.png";
import partnersList from "../../images/partnersList.svg";

export default function HeroSection() {
  return (
    <section>
      {/* main content  */}
      <div className="mx-16 grid grid-cols-2">
        <div className="my-10 mr-[-5em] justify-items-start text-left xl:mt-28 ">
          <p className="text-xl  text-secondary xl:mb-4 xl:text-2xl">
            Provison Education Platform
          </p>
          <h1
            style={{ fontFamily: "Space Grotesk" }}
            className="line text-5xl font-bold leading-tight text-white xl:text-7xl "
          >
            Become the greatest,
            <br />
            Think like a Pro.
          </h1>

          <p className="mb-8 mt-6 text-base text-white xl:mt-8 xl:text-2xl">
            Start your journey in programming.
          </p>
          <GradientButton>Start now</GradientButton>
          <SecondButton className={"mx-2 xl:mx-4"}>About us ↗</SecondButton>
        </div>
        <div className="w-full pl-[36%] pt-2">
          <img
            className=" "
            src={CoolGuy}
            alt="Mahmoud k yekber ou yechri vr"
          />
        </div>
      </div>
      <div className="flex flex-col items-center ">
        <p className="text-md pb-4 font-extralight text-white lg:text-lg ">
          Our amazing partners:
        </p>
        <img className="w-7/12 " src={partnersList} />
      </div>
    </section>
  );
}
