function solve() {

  const [generate, buy] = Array.from(document.querySelectorAll('button'));
  const [input, output] = Array.from(document.querySelectorAll('textarea'));
  generate.addEventListener('click', onGenerate);
  buy.addEventListener('click', onBuy);

  function onGenerate(e){

    const data = JSON.parse(input.value);

    for(let item of data){
      const row = document.createElement('tr');
      const cells = 
    }
  }

  function onBuy(e){

  }
}