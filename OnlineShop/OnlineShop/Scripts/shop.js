
function getProducts() {
    appAjaxRequest("/Product/GetProducts").done(onGetProductsDone);
}

function onGetProductsDone(response) {
    var goodsDiv = $('#goods_div');
    goodsDiv.empty();
    for(var i = response.data.length - 1; i >= 0; i--)
    {
        var item = response.data[i];
        var productDiv = document.createElement('div');
        productDiv.className = 'product_div';
        productDiv.innerHTML =
                '<input type="hidden" name="product_id" value="' + item.Id + '" />' +
                '<img class="product_img" src="/Pictures/' + item.Image + '" />' +
                '<div class="product_name_div"><a href="#">' + item.Name + '</a></div>' +
                '<div>' +
                    '<div class="product_price_div">' + item.Price + ' <span>грн.</span></div>' +
                    '<button id="btn_prod_id:' + item.Id + '" class="btn_m btn_basket" onclick="addIntoBasket(' + item.Id + ')" >Купить</button>' +
                '</div>' +
                '<div class="product_quantity_div">В наличии: ' + item.Quantity + '</div>' +
                '<button class="btn_s btn_edit" onclick="window.open(\'/Product/ProductEditing?Id=' + item.Id + '\', \'_self\')">Редактировать</button>' +
                '<button class="btn_s btn_del" onclick="deleteProduct(' + item.Id + ',\'' + item.Name + '\')">Удалить</button>'
        ;

        goodsDiv.append(productDiv);
        checkUserProductList();
    }
}

function deleteProduct(product_id, name) {
    isConfirmed = confirm("Подтвердите удаление продукта\n" +
                          "ID: " + product_id + "\n" +
                          "Название: \'" + name + "\' ");
    if (isConfirmed) {
        var data = { productId : product_id };
        appAjaxRequest("/Product/DeleteProduct", "POST", JSON.stringify(data) ).complete(getGoods);
    }
}

function addIntoBasket(product_id){
    var data = { productId : product_id };
    appAjaxRequest("/Order/AddIntoBasket", "POST", JSON.stringify(data)).complete(checkUserProductList);
}

function checkUserProductList() {
    appAjaxRequest("/Order/GetCurrentUserProductsIdList").done(onGetCurrentUserProductIdList);
}

function onGetCurrentUserProductIdList(response) {
    for(var i = response.data.length - 1; i >= 0; i--){
        var productId = response.data[i];
        var btn = $("#btn_prod_id:" + item.Id);
        if (btn !== undefined) {
            btn.Disabled = true;
            btn.Value = "В корзине";
        }
    }
}




