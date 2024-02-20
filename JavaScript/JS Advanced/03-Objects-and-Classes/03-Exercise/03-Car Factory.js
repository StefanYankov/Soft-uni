function solve(input = {}) {
  const output = {
    model: input.model,
    engine: {
      power: undefined,
      volume: undefined,
    },
    carriage: {
      type: input.carriage,
      color: input.color,
    },
    wheels: new Array(4),
  };

  if (input.power <= 90) {
    output.engine.power = 90;
    output.engine.volume = 1800;
  } else if (input.power <= 120) {
    output.engine.power = 120;
    output.engine.volume = 2400;
  } else {
    output.engine.power = 200;
    output.engine.volume = 3500;
  }

  if (input.wheelsize % 2 === 0) {
    output.wheels.fill(input.wheelsize - 1);
  } else {
    output.wheels.fill(input.wheelsize);
  }
  return output;
}

console.log(
  solve({
    model: "VW Golf II",
    power: 90,
    color: "blue",
    carriage: "hatchback",
    wheelsize: 14,
  })
);
console.log("_______________");
console.log(
  solve({
    model: "Opel Vectra",
    power: 110,
    color: "grey",
    carriage: "coupe",
    wheelsize: 17,
  })
);
