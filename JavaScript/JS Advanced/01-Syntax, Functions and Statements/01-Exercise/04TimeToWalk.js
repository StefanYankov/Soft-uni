function timeToWalk(inputFirstNumber, inputSecondNumber, inputThirdNumber){
    let steps = inputFirstNumber;
    let footprintLength = inputSecondNumber; // in meters
    let studentSpeed = inputThirdNumber; // km/h

    let distance = steps * footprintLength;
    let breaks = Math.floor(distance/500) * 60;
    //Every 500 meters the students a rest and takes a 1 minute break.
    // time = distance/speed
    let time = Math.round(distance / (studentSpeed * 0.27777777777778)) + breaks;

    console.log(new Date(time * 1000).toISOString().substr(11, 8)); // convert seconds to 'hours:minutes:seconds'
}

timeToWalk(4000, 0.60, 5);