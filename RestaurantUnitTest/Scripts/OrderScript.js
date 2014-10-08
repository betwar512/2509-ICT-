
function myFunction() {
    var x;
    if (confirm("Press a button!") == true) {
        x = "You pressed OK!";
    } else {
        x = "You pressed Cancel!";
    }
    document.getElementById("demo").innerHTML = x;
}






function addOrder() {
    var person = prompt("Please enter your name", "Harry Potter");

    if (person != null) {
        $.ajax({
            url: '/Orders/',
            contentType: 'application/html; charset=utf-8',
            data: { OrderItem:orderItem},
            type: 'Get',
            dataType: 'html'
              })
  .success(function (result) {

      $('#detail').html(result);
         })
     .error(function (xhr, status) {
          alert(status);
      })
   }
}