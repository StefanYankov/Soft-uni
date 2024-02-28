function solve(data, criteria = "") {
  const parsedData = JSON.parse(data);
  const [criteriaKey, criteriaValue] = criteria.split("-");

  const outputData = [];
  let objId = 0;

  for (let obj of parsedData) {
    if (obj[criteriaKey] === criteriaValue) {
      let person = {
        id: objId++,
        fullName: obj.first_name + " " + obj.last_name,
        email: obj.email,
      };

      outputData.push(person);
    }
  }

  let outputString = "";

  for (let person of outputData) {
    outputString += `${person.id}. ${person.fullName} - ${person.email}\n`;
  }

  return outputString.trim();
}

solve(
  `[{

    "id": "1",
    
    "first_name": "Ardine",
    
    "last_name": "Bassam",
    
    "email": "abassam0@cnn.com",
    
    "gender": "Female"
    
    }, {
    
    "id": "2",
    
    "first_name": "Kizzee",
    
    "last_name": "Jost",
    
    "email": "kjost1@forbes.com",
    
    "gender": "Female"
    
    },
    
    {
    
    "id": "3",
    
    "first_name": "Evanne",
    
    "last_name": "Maldin",
    
    "email": "emaldin2@hostgator.com",
    
    "gender": "Male"
    
    }]`,

  "gender-Female"
);
console.log("___________________________");
// solve(
//   `[{

// "id": "1",

// "first_name": "Kaylee",

// "last_name": "Johnson",

// "email": "k0@cnn.com",

// "gender": "Female"

// }, {

// "id": "2",

// "first_name": "Kizzee",

// "last_name": "Johnson",

// "email": "kjost1@forbes.com",

// "gender": "Female"

// }, {

// "id": "3", 0. Kaylee Johnson - k0@cnn.com 1. Kizzee Johnson - kjost1@forbes.com 2. Evanne Johnson - ev2@hostgator.com

// "first_name": "Evanne", "last_name": "Maldin", "email": "emaldin2@hostgator.com", "gender": "Male" }, { "id": "4", "first_name": "Evanne", "last_name": "Johnson", "email": "ev2@hostgator.com", "gender": "Male" }]`,
//   "last_name-Johnson"
// );
