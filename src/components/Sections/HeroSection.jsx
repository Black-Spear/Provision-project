import GradientButton from "../Buttons/gradientButton";
import SecondButton from "../Buttons/secondegradientButton";
// Graphic assets
import CoolGuy from "../../images/RightGraphicCoolGuyCoolGuy.png";
import partnersList from "../../images/partnersList.svg";

export default function HeroSection() {
  return (
    <section>
      {/* main content  */}
      <div className="mx-4 grid md:grid-cols-[7fr_3fr] lg:mx-16">
        <div className="order-2 mt-16 flex flex-col text-center sm:text-left lg:order-1 lg:mt-16 xl:mt-28">
          <p className="text-md text-secondary  lg:text-xl xl:mb-4 xl:text-2xl">
            Provison Education Platform
          </p>
          <h1
            style={{ fontFamily: "Space Grotesk" }}
            className="text-3xl font-bold leading-tight text-white md:text-4xl xl:text-6xl "
          >
            Become the greatest,
            <br />
            Think like a Pro.
          </h1>
          <p className="mb-4 mt-3 text-sm text-white lg:mb-8 lg:mt-6 lg:text-base xl:mt-8 xl:text-2xl">
            Start your journey in programming.
          </p>
          <GradientButton className={"m-auto w-fit sm:m-0"}>
            Start now
          </GradientButton>
          <SecondButton className={"lg: mx-2 hidden xl:mx-4"}>
            About us
          </SecondButton>
        </div>
        <div className="order-1 px-10 sm:px-32 md:order-2 md:px-0 md:pt-2 xl:pt-8 ">
          <img src={CoolGuy} alt="Mahmoud k yekber ou yechri vr" />
        </div>
      </div>
      <div className="mt-[4vh] flex flex-col items-center">
        <p className="text-md pb-4 font-extralight text-white lg:text-lg ">
          Our amazing partners:
        </p>
        <img className="w-[90%] lg:w-7/12 " src={partnersList} />
      </div>
    </section>
  );
}
