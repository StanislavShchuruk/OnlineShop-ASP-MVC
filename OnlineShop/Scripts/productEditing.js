
getProductTypes();
getBrands();

var chosenImage = null;

$('#choose_image[type=file]').change(function () {
    chosenImage = this.files[0];
});

$('#btn_upload_img').click(function () {

    if (chosenImage == null) return; 

    var data = new FormData();
    data.append("chosenImage", chosenImage);

    appAjaxRequest("/Home/UploadImage", "POST", data, false, false
                            ).done(onImageUploadDone).fail(onFailCommon);
});

function onImageUploadDone(response) {
    if (response != null) {
        document.getElementById('uploaded_image').src = '/Pictures/' + response;
        document.getElementById('image_name').value = response;
    }
}

function getBrands() {
    appAjaxRequest("/Brand/GetBrands").done(onGetBrandsDone).fail(onFailCommon);
}

function getProductTypes() {
    appAjaxRequest("/ProductType/GetProductTypes").done(onGetProductTypesDone).fail(onFailCommon);
}

//Brands
function onGetBrandsDone(response) {
    var selectList = $('#brand_select');
    selectList.empty();
    response.data.forEach(
    function (item) {
        var optionItem = document.createElement('option');
        optionItem.innerHTML = item.Name;
        if (+$('#editing_brand_id')[0].value == item.Id)
            optionItem.selected = true;

        selectList.append(optionItem);
    });
}

//Product Types
function onGetProductTypesDone(response) {
    var selectList = $('#product_type_select');
    selectList.empty();
    response.data.forEach(
    function (item) {
        var optionItem = document.createElement('option');
        optionItem.innerHTML = item.Name;
        if (+$('#editing_product_type_id')[0].value == item.Id)
            optionItem.selected = true;

        selectList.append(optionItem);
    });
}

function onAddingOption(hide_name, show_name) {
    document.getElementsByName(hide_name).forEach(function(item) { item.style.display = 'none'; });
    document.getElementsByName(show_name).forEach(function (item) { item.style.display = 'inline-block'; });
}

function addProductType() {
    var data = { productTypeName : $('#new_type')[0].value };
    appAjaxRequest("/ProductType/AddProductType", "POST", JSON.stringify(data)
                   ).complete(onAddProductTypeComplete);
}

function onAddProductTypeComplete(response) {
    $('#new_type')[0].value;
    getProductTypes();
    onAddingOption('add_type', 'new_type');
}

function deleteProductType(){
    var removable_productType_name = $('#product_type_select')[0].value;

    if (removable_productType_name == "") return;

    var isConfirmed = confirm('Подтвердите удаление типа продуктов "' + removable_productType_name + '"?');
    
    if(isConfirmed)
    {
        data = { productTypeName: removable_productType_name };
        appAjaxRequest("/ProductType/DeleteProductType", "POST", JSON.stringify(data)
                        ).complete(onDeleteProductTypeComplete);
    }
}

function onDeleteProductTypeComplete(response) {
    var response_data = JSON.parse(response.responseText);
    if (response_data.isSuccess) getProductTypes();
    else alert(response_data.error_message);
}

function addBrand() {
    var data = { brandName: $('#new_brand')[0].value };
    appAjaxRequest("/Brand/AddBrand", "POST", JSON.stringify(data)
                    ).complete(onAddBrandComplete);
}

function onAddBrandComplete(response) {
    $('#new_brand')[0].value = "";
    getBrands();
    onAddingOption('add_brand', 'new_brand');
}

function deleteBrand() {
    var removable_brand_name = $('#brand_select')[0].value;

    if (removable_brand_name == "") return;

    var isConfirmed = confirm('Подтвердите удаление бренда "' + removable_brand_name + '"?');

    if (isConfirmed)
    {
        data = { brandName : removable_brand_name };
        appAjaxRequest("/Brand/DeleteBrand", "POST", JSON.stringify(data)
            ).complete(onDeleteBrandComplete);
    }
}

function onDeleteBrandComplete(response)
{
    var response_data = JSON.parse(response.responseText);
    if (response_data.isSuccess) getBrands();
    else alert(response_data.error_message);
}

