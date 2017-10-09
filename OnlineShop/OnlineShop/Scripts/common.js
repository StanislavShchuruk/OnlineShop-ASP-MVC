
function appAjaxRequest(_url, _method, _data, _contentType, _processData, _dataType) {
    if (_method === undefined) _method = "POST";
    if (_data === undefined) _data = null;
    if (_contentType === undefined) _contentType = "application/json";
    if (_processData === undefined) _processData = true;
    if (_dataType === undefined) _dataType = "json";
    return $.ajax({
        url: _url,
        data: _data,
        contentType: _contentType,
        processData: _processData,
        dataType: _dataType,
        method: _method
    })
}

function onFailCommon(error) {
    alert('operation was failed. Error: ' + error.statusText + ' ' + error.status);
}