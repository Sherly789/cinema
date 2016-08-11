$(document).ready(function(){

$("#order-qt-input").change(inputEvent).keyup(inputEvent);

function inputEvent(){
  var temp=$(this).val();
  var price =parseInt(temp)*10;
  $("#total-price").text(price);
}
});
