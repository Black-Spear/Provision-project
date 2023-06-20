/* eslint-disable react/prop-types */
export default function GradientButton({ children, onClick, ...props }) {
  return (
    <>
      <button
        style={{ boxShadow: "0px 0px 15px 0px #5eb6ae" }}
        onClick={onClick}
        className="rounded-2xl bg-gradient-to-r from-blue from-30% to-primary px-8 py-2 text-white "
        {...props}
      >
        {children}
      </button>
    </>
  );
}
