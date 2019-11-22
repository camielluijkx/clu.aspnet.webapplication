var connection = new signalR.HubConnectionBuilder()
    .withUrl("/chathub")
    .withHubProtocol(new signalR.protocols.msgpack.MessagePackHubProtocol())
    .build();

connection.on("NewMessage", (sender, message) => {
    $(".chatLog").text($(".chatLog").text() + " Message from " + sender + ":" + message);
});

connection.on("UserListUpdate", (userList) => {
    $(".users").text(userList);
});

connection.start().catch(err => console.error(err.toString()));

$(".all").click(function () {
    var sender = $(".username").val();
    var message = $(".message").val();
    connection.invoke("MessageAll", sender, message);
});

$(".join").click(function () {
    var sender = $(".username").val();
    connection.invoke("JoinChatRoom", sender);
});

$(".leave").click(function () {
    connection.invoke("LeaveChatRoom");
});

$(".message").click(function () {
    var message = $(".message").val();
    connection.invoke("MessageChatRoom", message);
});