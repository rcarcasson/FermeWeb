$(document).ready(function () {
    $("#listaproductos a").addClass("list-group-item list-group-item-action");
    console.log("Valor de carro: " + $("#ContentPlaceHolder1_lbCantidadCarro").text());
    $("#totalcarro").html($("#ContentPlaceHolder1_lbCantidadCarro").text());
})