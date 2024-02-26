function encodeAndDecodeMessages() {
  const buttons = document.querySelectorAll("main div button");

  const encodeButton = buttons[0];
  encodeButton.addEventListener("click", encode);

  const decodeButton = buttons[1];
  decodeButton.addEventListener("click", decode);

  let encodedMessage = "";

  function encode(event) {
    const parentElement = event.currentTarget.parentNode;
    const textArea = parentElement.querySelector("textarea");
    encodedMessage = textArea.value;
    textArea.value = "";

    decodeButton.parentNode.querySelector("textarea").value =
      cipher(encodedMessage);
  }

  function decode(event) {
    const parentElement = event.currentTarget.parentNode;
    const textArea = parentElement.querySelector("textarea");
    encodedMessage = textArea.value;
    textArea.value = decipher(encodedMessage);
  }

  function cipher(input = "") {
    let cipheredMessage = "";
    for (let i = 0; i < input.length; i++) {
      // Convert character to ASCII code and add 1
      let ascii = input.charCodeAt(i) + 1;
      // encode the character and append to the ciphered message

      cipheredMessage += String.fromCharCode(ascii);
    }
    return cipheredMessage;
  }
  function decipher(input = "") {
    let decipheredMessage = "";
    for (let i = 0; i < input.length; i++) {
      // Convert character to ASCII code and subtract 1
      let ascii = input.charCodeAt(i) - 1;
      // Convert back to character and append to deciphered message
      decipheredMessage += String.fromCharCode(ascii);
    }
    return decipheredMessage;
  }
}
