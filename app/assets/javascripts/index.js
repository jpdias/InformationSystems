function loadPage(_url){
    $('#page-wrapper').empty();
    $('#page-wrapper').load(_url);
}

function convertMesIdToString(mes_id){
    if(mes_id == 1)
        return 'Janeiro';
    else
        if(mes_id == 2)
            return 'Fevereiro';
        else
            if(mes_id == 3)
                return 'Março';
            else
                if(mes_id == 4)
                    return 'Abril';
                else
                    if(mes_id == 5)
                        return 'Maio';
                    else
                        if(mes_id == 6)
                            return 'Junho';
                        else
                            if(mes_id == 7)
                                return 'Julho';
                            else
                                if(mes_id == 8)
                                    return 'Agosto';
                                else
                                    if(mes_id == 9)
                                        return 'Setembro';
                                    else
                                        if(mes_id == 10)
                                            return 'Outubro';
                                        else
                                            if(mes_id == 11)
                                                return 'Novembro';
                                            else
                                                if(mes_id == 12)
                                                    return 'Dezembro';
                                                else
                                                    return 'Unknown';
}