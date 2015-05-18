function btnDELETE_Click() {
    return confirm("確定是否刪除此筆資料?");
}

function btnCLEAR() {
    clearText($("#form1")[0].elements);

    // 如果使用clearText仍然沒有完全清空資料，請再加入以下要清空的欄位
    // $('#qcDELIVERY_TYPE').val('');
    // $('#qcFORWARDER_NO').val('');
    // $('#qcCOMPANY_NAME').val('');
    // $('#qcADDRESS').val('');
    // $('#qcTEL1').val('');
    // $('#qcTEL2').val('');
    // $('#qcFAX1').val('');
    // $('#qcFAX2').val('');
    // $('#qcE_MAIL1').val('');
    // $('#qcE_MAIL2').val('');
    // $('#qcPIC').val('');
    // $('#qcUPD_ID').val('');
    // $('#qcUPD_DATE').val('');
    // $('#qcUPD_TIME').val('');

    return false; // 避免 postback
}

function btnSave_Click() {

    // 清空錯誤訊息
    InitErr();

    var g_ButtonType = $("#hidACT_TYPE").val(); // 上一頁執行的動作(修改UPD, 查詢QRY, 複製COPY, 新增ADD, 刪除DEL)

    // 自訂檢驗(必填欄位)
    //ErrCtrl($('#qcDELIVERY_TYPE'), '運送方式格式錯誤!', validationEngine, 'checkDELIVERY_TYPE');
    //ErrCtrl($('#qcFORWARDER_NO'), '運輸代理商代號格式錯誤!', validationEngine, 'checkFORWARDER_NO');
    //ErrCtrl($('#qcCOMPANY_NAME'), '運輸代理商名稱格式錯誤!', validationEngine, 'checkCOMPANY_NAME');
    //ErrCtrl($('#qcADDRESS'), '地址格式錯誤!', validationEngine, 'checkADDRESS');
    //ErrCtrl($('#qcTEL1'), '電話1格式錯誤!', validationEngine, 'checkTEL1');
    //ErrCtrl($('#qcTEL2'), '電話2格式錯誤!', validationEngine, 'checkTEL2');
    //ErrCtrl($('#qcFAX1'), '傳真號碼1格式錯誤!', validationEngine, 'checkFAX1');
    //ErrCtrl($('#qcFAX2'), '傳真號碼2格式錯誤!', validationEngine, 'checkFAX2');
    //ErrCtrl($('#qcE_MAIL1'), 'E-MAIL1格式錯誤!', validationEngine, 'checkE_MAIL1');
    //ErrCtrl($('#qcE_MAIL2'), 'E-MAIL2格式錯誤!', validationEngine, 'checkE_MAIL2');
    //ErrCtrl($('#qcPIC'), '連絡人格式錯誤!', validationEngine, 'checkPIC');
    //ErrCtrl($('#qcUPD_ID'), '更新者格式錯誤!', validationEngine, 'checkUPD_ID');
    //ErrCtrl($('#qcUPD_DATE'), '更新日期格式錯誤!', validationEngine, 'checkUPD_DATE');
    //ErrCtrl($('#qcUPD_TIME'), '更新時間格式錯誤!', validationEngine, 'checkUPD_TIME');

    // 自訂檢驗(非必填欄位，有輸入才檢驗)
    //if ($('#qcDELIVERY_TYPE').val() != '')
    //	ErrCtrl($('#qcDELIVERY_TYPE'), '運送方式格式錯誤!', validationEngine, 'checkDELIVERY_TYPE');
    //if ($('#qcFORWARDER_NO').val() != '')
    //	ErrCtrl($('#qcFORWARDER_NO'), '運輸代理商代號格式錯誤!', validationEngine, 'checkFORWARDER_NO');
    //if ($('#qcCOMPANY_NAME').val() != '')
    //	ErrCtrl($('#qcCOMPANY_NAME'), '運輸代理商名稱格式錯誤!', validationEngine, 'checkCOMPANY_NAME');
    //if ($('#qcADDRESS').val() != '')
    //	ErrCtrl($('#qcADDRESS'), '地址格式錯誤!', validationEngine, 'checkADDRESS');
    //if ($('#qcTEL1').val() != '')
    //	ErrCtrl($('#qcTEL1'), '電話1格式錯誤!', validationEngine, 'checkTEL1');
    //if ($('#qcTEL2').val() != '')
    //	ErrCtrl($('#qcTEL2'), '電話2格式錯誤!', validationEngine, 'checkTEL2');
    //if ($('#qcFAX1').val() != '')
    //	ErrCtrl($('#qcFAX1'), '傳真號碼1格式錯誤!', validationEngine, 'checkFAX1');
    //if ($('#qcFAX2').val() != '')
    //	ErrCtrl($('#qcFAX2'), '傳真號碼2格式錯誤!', validationEngine, 'checkFAX2');
    //if ($('#qcE_MAIL1').val() != '')
    //	ErrCtrl($('#qcE_MAIL1'), 'E-MAIL1格式錯誤!', validationEngine, 'checkE_MAIL1');
    //if ($('#qcE_MAIL2').val() != '')
    //	ErrCtrl($('#qcE_MAIL2'), 'E-MAIL2格式錯誤!', validationEngine, 'checkE_MAIL2');
    //if ($('#qcPIC').val() != '')
    //	ErrCtrl($('#qcPIC'), '連絡人格式錯誤!', validationEngine, 'checkPIC');
    //if ($('#qcUPD_ID').val() != '')
    //	ErrCtrl($('#qcUPD_ID'), '更新者格式錯誤!', validationEngine, 'checkUPD_ID');
    //if ($('#qcUPD_DATE').val() != '')
    //	ErrCtrl($('#qcUPD_DATE'), '更新日期格式錯誤!', validationEngine, 'checkUPD_DATE');
    //if ($('#qcUPD_TIME').val() != '')
    //	ErrCtrl($('#qcUPD_TIME'), '更新時間格式錯誤!', validationEngine, 'checkUPD_TIME');

    // 當主主頁執行的動作為(複製COPY, 新增ADD)，需要額外檢驗主鍵值是否重複
    if (g_ButtonType == "ADD" || g_ButtonType == "COPY") {
        // ErrCtrl($('#qcDELIVERY_TYPE'), '主鍵值已經存在,請確認!', validationEngine, 'isDuplicated'); // 如果qcDELIVERY_TYPE不是主鍵值欄位，請移除這一行
        // ErrCtrl($('#qcFORWARDER_NO'), '主鍵值已經存在,請確認!', validationEngine, 'isDuplicated'); // 如果qcFORWARDER_NO不是主鍵值欄位，請移除這一行
        // ErrCtrl($('#qcCOMPANY_NAME'), '主鍵值已經存在,請確認!', validationEngine, 'isDuplicated'); // 如果qcCOMPANY_NAME不是主鍵值欄位，請移除這一行
        // ErrCtrl($('#qcADDRESS'), '主鍵值已經存在,請確認!', validationEngine, 'isDuplicated'); // 如果qcADDRESS不是主鍵值欄位，請移除這一行
        // ErrCtrl($('#qcTEL1'), '主鍵值已經存在,請確認!', validationEngine, 'isDuplicated'); // 如果qcTEL1不是主鍵值欄位，請移除這一行
        // ErrCtrl($('#qcTEL2'), '主鍵值已經存在,請確認!', validationEngine, 'isDuplicated'); // 如果qcTEL2不是主鍵值欄位，請移除這一行
        // ErrCtrl($('#qcFAX1'), '主鍵值已經存在,請確認!', validationEngine, 'isDuplicated'); // 如果qcFAX1不是主鍵值欄位，請移除這一行
        // ErrCtrl($('#qcFAX2'), '主鍵值已經存在,請確認!', validationEngine, 'isDuplicated'); // 如果qcFAX2不是主鍵值欄位，請移除這一行
        // ErrCtrl($('#qcE_MAIL1'), '主鍵值已經存在,請確認!', validationEngine, 'isDuplicated'); // 如果qcE_MAIL1不是主鍵值欄位，請移除這一行
        // ErrCtrl($('#qcE_MAIL2'), '主鍵值已經存在,請確認!', validationEngine, 'isDuplicated'); // 如果qcE_MAIL2不是主鍵值欄位，請移除這一行
        // ErrCtrl($('#qcPIC'), '主鍵值已經存在,請確認!', validationEngine, 'isDuplicated'); // 如果qcPIC不是主鍵值欄位，請移除這一行
        // ErrCtrl($('#qcUPD_ID'), '主鍵值已經存在,請確認!', validationEngine, 'isDuplicated'); // 如果qcUPD_ID不是主鍵值欄位，請移除這一行
        // ErrCtrl($('#qcUPD_DATE'), '主鍵值已經存在,請確認!', validationEngine, 'isDuplicated'); // 如果qcUPD_DATE不是主鍵值欄位，請移除這一行
        // ErrCtrl($('#qcUPD_TIME'), '主鍵值已經存在,請確認!', validationEngine, 'isDuplicated'); // 如果qcUPD_TIME不是主鍵值欄位，請移除這一行
    }
    // 執行預設檢驗項目(AllowEmpty, TypeMode==number, TypeMode==date || TypeMode==dateR, DataFormat)
    return isValid();
}

var validationEngine = {
    // 自訂驗證方法
    checkDELIVERY_TYPE: function () { return true; },
    checkFORWARDER_NO: function () { return true; },
    checkCOMPANY_NAME: function () { return true; },
    checkADDRESS: function () { return true; },
    checkTEL1: function () { return true; },
    checkTEL2: function () { return true; },
    checkFAX1: function () { return true; },
    checkFAX2: function () { return true; },
    checkE_MAIL1: function () { return true; },
    checkE_MAIL2: function () { return true; },
    checkPIC: function () { return true; },
    checkUPD_ID: function () { return true; },
    checkUPD_DATE: function () { return true; },
    checkUPD_TIME: function () { return true; },
    isDuplicated: function () {
        var m_Return = true;

        // 將所有欄位傳上去

        // List<string> keyVals = QueryConditions.Select(hc => string.Format("{0}: {1}", hc.Name, hc.GetJsonValue())).ToList();

        var data = JSON.stringify({
            p_DELIVERY_TYPE: $('#qcDELIVERY_TYPE').val(),
            p_FORWARDER_NO: $('#qcFORWARDER_NO').val(),
            p_COMPANY_NAME: $('#qcCOMPANY_NAME').val(),
            p_ADDRESS: $('#qcADDRESS').val(),
            p_TEL1: $('#qcTEL1').val(),
            p_TEL2: $('#qcTEL2').val(),
            p_FAX1: $('#qcFAX1').val(),
            p_FAX2: $('#qcFAX2').val(),
            p_E_MAIL1: $('#qcE_MAIL1').val(),
            p_E_MAIL2: $('#qcE_MAIL2').val(),
            p_PIC: $('#qcPIC').val(),
            p_UPD_ID: $('#qcUPD_ID').val(),
            p_UPD_DATE: $('#qcUPD_DATE').val(),
            p_UPD_TIME: $('#qcUPD_TIME').val(),
        });

        $.ajax({
            type: "POST",
            async: false,
            url: "BASM0070.aspx/isDuplicated",
            data: data,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            error: function (xmlHttpRequest, error) {
                var m_ErrMessage = xmlHttpRequest.responseText;
                alert(m_ErrMessage);
            },
            success: function (data) {
                m_Return = !(data.d);
            }
        });

        return m_Return;
    }
};
