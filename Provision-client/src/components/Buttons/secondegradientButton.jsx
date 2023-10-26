import classNames from "classnames";
import PropTypes from "prop-types";
export default function SecondButton({
  children,
  className,
  onClick,
  ...props
}) {
  const cx = classNames([
    " border-2  border-white text-white rounded-2xl py-2 px-4  ",
    className,
  ]);
  return (
    <button onClick={onClick} className={cx} {...props}>
      {children}
    </button>
  );
}
SecondButton.propTypes = {
  children: PropTypes.node.isRequired,
  className: PropTypes.string,
  onClick: PropTypes.func,
};
