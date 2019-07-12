function validar_rut(source, arguments)
{
    var rut=arguments.Value;suma=0;mul=2;i=0;

    for (i=rut.length-3;i>=0;i--)
    {
        suma=suma+parseInt(rut.charAt(i)) * mul;
        mul= mul==7 ? 2 : mul+1;
    }

    var dvr = ''+(11 - suma % 11);
    if (dvr=='10') {
        dvr = 'K'; 
    }else if (dvr=='11') {
        dvr = '0';
    }

    if (rut.charAt(rut.length - 2) != "-" || rut.charAt(rut.length - 1).toUpperCase() != dvr) {
        arguments.IsValid = false;
    } else {
        arguments.IsValid = true;
    }

}
