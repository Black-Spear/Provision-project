import GradientButton from "../Buttons/gradientButton";
import SecondButton from "../Buttons/secondegradientButton";

export default function HeroSection() {
  return (
    <section>
      <div className="grid grid-cols-1 justify-items-center ">
        <div className="text-center my-14     ">
          <p className="text-secondary  text-xl ">
            Provison Education Platform
          </p>
          <h1 className="text-6xl  font-bold leading-normal text-white ">
            Become the greatest,
          </h1>
          <h1 className="text-6xl font-bold leading-normal text-white ">
            Think like a pro
          </h1>
          <p className="mt-4 mb-5 text-white text-base">
            Start your journey in programming.
          </p>
        </div>
        <div className="flex">
          <GradientButton>Get started</GradientButton>
          <SecondButton className={"mx-2"}>About us</SecondButton>
        </div>
      </div>
    </section>
  );
}
