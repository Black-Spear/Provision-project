/* eslint-disable react/prop-types */
export default function GradientButton({ children, onClick, ...props }) {
  return (
    <button
      onClick={onClick}
      className="bg-gradient-to-r from-blue from-30% to-primary   text-white rounded-2xl py-2 px-8 my-5 mx-2 "
      {...props}
    >
      {children}
    </button>
  );
}
