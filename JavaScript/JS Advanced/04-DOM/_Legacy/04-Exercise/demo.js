function myFunction() {
    const x = document.getElementById('input');
    const convertButton = document.getElementsByTagName('button')[0];
    const result = document.getElementById('result');
    
    convertButton.addEventListener('click', function () {
        if (x === 0) {
            return 1;
         } else {
          return v1 * factorial(x-1);
        }
    }
 
} 
