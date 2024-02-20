function solve(input = {}) {
  requiredWaterPerKg = 0.1;
  if (input.dizziness === true) {
    input.dizziness = false;

    input.levelOfHydrated +=
      input.weight * input.experience * requiredWaterPerKg;
  }
  return input;
}

console.log(
  solve({ weight: 80, experience: 1, levelOfHydrated: 0, dizziness: true })
);
console.log("_______________");
console.log(
  solve({ weight: 120, experience: 20, levelOfHydrated: 200, dizziness: true })
);
console.log("_______________");
console.log(
  solve({ weight: 95, experience: 3, levelOfHydrated: 0, dizziness: false })
);
