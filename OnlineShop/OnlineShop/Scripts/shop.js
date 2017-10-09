(function () {

    getProducts();

    $('#btn-add').bind({
        click: function () {
            window.open('/Product/ProductEditing', '_self')
        }
    });
    $('#btn-basket').bind({ click: null });

    function getProducts() {
        appAjaxRequest("/Product/GetProducts").done(onGetProductsDone);
    }

    function onGetProductsDone(response) {
        var goodsDiv = $('#goods_div');
        goodsDiv.empty();
        for (var i = response.data.length - 1; i >= 0; i--) {
            var item = response.data[i];
            var productDiv = $(
                '<div class="product_div">' +
                    '<input type="hidden" name="product_id" value="' + item.Id + '" />' +
                    '<img class="product_img" src="/Pictures/' + item.Image + '" />' +
                    '<div class="product_name_div"><a href="#">' + item.Name + '</a></div>' +
                    //'<div>' +
                        '<div class="product_price_div">' + item.Price + ' <span>грн.</span></div>' +
                        '<button id="btn-buy-' + item.Id + '" class="btn_m btn_basket" >Купить</button>' +
                    //'</div>' +
                    '<div class="product_quantity_div">В наличии: ' + item.Quantity + '</div>' +
                    '<button id="btn-edit-' + item.Id + '" class="btn_s btn_edit" >Редактировать</button>' +
                    '<button id="btn-delete-' + item.Id + '" class="btn_s btn_del" >Удалить</button>' +
               '</div>'
            );

            productDiv.children('#btn-edit-' + item.Id).bind({
                click: function() {
                    window.open(('/Product/ProductEditing?Id=' + item.Id), '_self');
                }
            });
            productDiv.children('#btn-delete-' + item.Id).bind({
                click: function () {
                    deleteProduct(item.Id, item.Name);
                }
            });
            productDiv.children('#btn-buy-' + item.Id).bind({
                click: function () {
                    addIntoBasket(item.Id);
                }
            });

            //document.createElement('div');
            //productDiv.className = 'product_div';

            goodsDiv.append(productDiv);
        }
        checkUserProductList();
    }

    function deleteProduct(product_id, name) {
        isConfirmed = confirm("Подтвердите удаление продукта\n" +
                              "ID: " + product_id + "\n" +
                              "Название: \'" + name + "\' ");
        if (isConfirmed) {
            var data = { productId: product_id };
            appAjaxRequest("/Product/DeleteProduct", "POST", JSON.stringify(data)).complete(getProducts);
        }
    }

    function addIntoBasket(product_id) {
        var data = { productId: product_id };
        appAjaxRequest("/Order/AddIntoBasket", "POST", JSON.stringify(data)).complete(checkUserProductList);
    }

    function checkUserProductList() {
        appAjaxRequest("/Order/GetCurrentUserProductsIdList").done(onGetCurrentUserProductIdList);
    }

    function onGetCurrentUserProductIdList(response) {
        for (var i = 0; i < response.data.length; i++) {
            var productId = response.data[i];
            var btn = $("#btn-buy-" + productId)[0];
            if (btn !== undefined) {
                btn.disabled = true;
                btn.textContent = "В корзине";
            }
        }
    }

})();




