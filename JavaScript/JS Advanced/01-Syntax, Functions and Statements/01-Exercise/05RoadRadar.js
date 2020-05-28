function roadRadar([speed, inputArea]){

    let kilometers = speed;
    let area = inputArea;

    const motorwayLimit = 130;
    const interstateLimit = 90;
    const cityLimit = 50;
    const residentialLimit = 20;

    let checkSpeeding = (kilometers, limit) => {
        if (kilometers <= limit){
            return;
        } else {
            if ( kilometers <= limit + 20) {
                console.log( "speeding");
            } else if (kilometers <= limit + 40) {
                console.log("excessive speeding");
            } else {
                console.log("reckless driving");
            }
        }
    };

    switch (area){
        case "motorway" :
            checkSpeeding(kilometers, motorwayLimit);
            break;
        case "interstate" :
            checkSpeeding(kilometers, interstateLimit);
            break;
        case "city" :
            checkSpeeding(kilometers, cityLimit);
            break;
        case "residential" :
            checkSpeeding(kilometers, residentialLimit);
            break;  
    }
}

roadRadar([40,'city']);
roadRadar([21, 'residential']);
roadRadar([120, 'interstate']);
roadRadar([200, 'motorway']);
