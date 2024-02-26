function attachEventsListeners() {
  const unitToMeter = {
    km: 1000,
    m: 1,
    cm: 0.01,
    mm: 0.001,
    mi: 1609.34,
    yrd: 0.9144,
    ft: 0.3048,
    in: 0.0254,
  };
  const inputValue = document.getElementById("inputDistance");
  const inputUnit = document.getElementById("inputUnits");

  const convertBtn = document.getElementById("convert");

  const outputValue = document.getElementById("outputDistance");
  const outputUnit = document.getElementById("outputUnits");

  convertBtn.addEventListener("click", convertDistance);

  function convertDistance(event) {
    let fromUnit = inputUnit.options[inputUnit.selectedIndex].value;
    let toUnit = outputUnit.options[outputUnit.selectedIndex].value;
    let distanceFrom = Number(inputValue.value);
    let distanceTo =
      (distanceFrom * unitToMeter[fromUnit]) / unitToMeter[toUnit];
    debugger;

    outputValue.value = distanceTo;
  }
}
