import React, { memo, useMemo } from "react";
import { Weapon } from "../../../db/weapons";
import { useConfig } from "../../../configs";
import { cx } from "emotion";
import LazyLoad from "react-lazyload";
import GameImage from "../../../gameImage";

const Icon = ({ weapon }: { weapon: Weapon }) => {
  const [existing] = useConfig("weapons");

  const alreadyAdded = useMemo(() => existing.includes(weapon.name), [
    existing,
    weapon.name,
  ]);

  return (
    <div
      className={cx(
        "inline-block m-1 text-center bg-white text-black rounded shadow-lg w-32",
        { "opacity-50": alreadyAdded }
      )}
    >
      <LazyLoad height="5rem">
        <GameImage
          name={weapon.name}
          className="w-20 h-20 mx-auto mt-2 object-cover"
        />
      </LazyLoad>

      <div className="text-center p-2 truncate">
        <div className="text-sm truncate">{weapon.name}</div>

        <div className="text-xs text-gray-600 truncate">
          <GameImage
            name={weapon.material.item}
            className="w-3 h-3 inline opacity-75"
          />

          <span className="align-middle"> {weapon.material.name}</span>
        </div>
      </div>
    </div>
  );
};

export default memo(Icon);
