function solve() {

   const sendButton = document.getElementById("send");
   const inputData = document.getElementById("chat_input")
   const messageHistory = document.getElementById("chat_messages");

   sendButton.addEventListener("click", function () {
       const currentInput = document.createElement("div");
       currentInput.className = "message my-message";
       currentInput.textContent = inputData.value;

       messageHistory.appendChild(currentInput);

       inputData.value = "";
   })
}