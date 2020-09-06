function encodeAndDecodeMessages() {
    const originalMessage = document.querySelector('div > textarea:not(disabled)');
    const originalDecode = document.querySelector('div > textarea[disabled]');

    const encodeButton = originalMessage.parentElement.querySelector('button');
    const decodeButton = originalDecode.parentElement.querySelector('button');
    
    encodeButton.addEventListener('click', encode);
    decodeButton.addEventListener('click', decode);

    function encode(){
        let inputMessage = originalMessage.value;
        let codedMessage = '';
        for (let i = 0; i < inputMessage.length; i++) {
            codedMessage += String.fromCharCode(inputMessage[i].charCodeAt(0) + 1);
        }

        originalDecode.value = codedMessage;
        originalMessage.value = '';
    }

    function decode(){
        let inputMessage = originalDecode.value;
        let decodedMessage = '';
        for (let i = 0; i < inputMessage.length; i++) {
            decodedMessage += String.fromCharCode(inputMessage[i].charCodeAt(0) - 1);
        }

        originalMessage.value = decodedMessage;
        originalDecode.value = '';
    }

}