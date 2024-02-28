function solution() {
  let output = "";

  function append(string) {
    output += string;
  }

  function removeStart(number) {
    output = output.substring(number);
  }

  function removeEnd(number) {
    output = output.substring(0, output.length - number);
  }

  function print() {
    console.log(output);
  }

  return {
    append,
    removeStart,
    removeEnd,
    print,
  };
}
{
  let firstZeroTest = solution();

  firstZeroTest.append("hello");

  firstZeroTest.append("again");

  firstZeroTest.removeStart(3);

  firstZeroTest.removeEnd(4);

  firstZeroTest.print();
}

{
  let secondZeroTest = solution();
  34;

  secondZeroTest.append("123");
  secondZeroTest.append("45");
  secondZeroTest.removeStart(2);
  secondZeroTest.removeEnd(1);
  secondZeroTest.print();
}
