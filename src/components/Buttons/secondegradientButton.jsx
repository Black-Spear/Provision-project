export default function SecondButton({ children,onClick,...props }) {
  return (
    <button
    onClick={onClick}
      className=" border-2  border-white text-white rounded-2xl py-2 px-4 my-5 mx-2 " {...props}>
      {children}
    </button>
  );
}


