async function bindVendorsToHtml(elementId) {
    let content = ``;
    let vendors = await getCardPinVendors();
    vendors.forEach(vendor => {
        var url = `${appConfig.appBaseUrl}/products?vendor=${vendor.id}`;
        content += ` <div class="col-xl-4 col-lg-4 col-md-6 col-sm-12 col-12">
                <div class="banner-wrap mb-30">
                    <div class="banner-img banner-img-zoom">
                        <a href="product-details.html"><img src="${appConfig.imageBaseUrl}/assets/images/banner/banner-3.jpg" alt=""></a>
                    </div>
                    <div class="banner-content-1">
                        <span></span>
                        <h2>${vendor.name}</h2>
                        <h3><span></span></h3>
                        <div class="btn-style-1">
                            <a class="font-size-14 btn-1-padding-2" href="${url}" >Shop now </a>
                        </div>
                    </div>
                    <div class="banner-badge banner-badge-position2">
                        <h3>
                            <span>Best</span>
                            Deal
                        </h3>
                    </div>
                </div>
            </div>`;
    });
    document.getElementById(elementId).innerHTML = content;
}

async function bindCardPinTypesDeals(elementId) {
    let content = ``;
    let cardPinTypes = await getCardPinTypes();
    cardPinTypes.forEach(cardPinType => {
        var vendorUrl = `${appConfig.appBaseUrl}/products?vendor=${cardPinType.cardPinVendorId}`;
        var detailsUrl = `${appConfig.appBaseUrl}/products/details/${cardPinType.id}`;
        content += `                        <div class="product-plr-1">
                            <div class="single-product-wrap">
                                <div class="product-badges product-badges-mrg">
                                    <span class="hot yellow">Sale</span>
                                    <span class="discount">  <a href="${vendorUrl}">${cardPinType.cardPinVendorName}</a></span>
                                </div>
                                <div class="product-content-wrap">
                                    <div class="product-category">
                                      
                                    </div>
                                    <h2><a href="${detailsUrl}">${cardPinType.name}</a></h2>
                                    <div class="product-price">
                                        <span class="new-price">₦${cardPinType.rate}</span>
                                        <span class="old-price"></span>
                                    </div>
                                </div>
                                <div class="product-img-action-wrap mb-20 mt-25">
                                    <div class="product-img product-img-zoom">
                                        <a href="${detailsUrl}">
                                            <img class="default-img" src="${appConfig.imageBaseUrl}/assets/images/product/product-3.jpg" alt="">
                                        </a>
                                    </div>
                                    <div class="product-action-1">
                                        <button onclick="handleAddToCart('${cardPinType.id}', '${cardPinType.name}', '${cardPinType.rate}', '${1}', '${cardPinType.id}')" aria-label="Add To Cart"><i class="far fa-shopping-cart"></i></button>
                                        <button aria-label="Add To Wishlist"><i class="far fa-heart"></i></button>
                                        <button aria-label="Compare"><i class="far fa-signal"></i></button>
                                    </div>
                                </div>
                                <div class="product-stock">
                                    
                                </div>
                            </div>
                        </div>`;
    });
    document.getElementById(elementId).innerHTML = content;
    initSlickSlider(elementId);
}

async function bindCardPinTypesProducts(elementId) {
    let content = ``;
    let cardPinTypes = await getCardPinTypes();
    cardPinTypes.forEach(cardPinType => {
        var vendorUrl = `${appConfig.appBaseUrl}/products?vendor=${cardPinType.cardPinVendorId}`;
        var detailsUrl = `${appConfig.appBaseUrl}/products/details/${cardPinType.id}`;
        content += ` <div class="custom-col-5">
                        <div class="single-product-wrap mb-50">
                            <div class="product-img-action-wrap mb-20">
                                <div class="product-img product-img-zoom">
                                    <a href="${detailsUrl}">
                                        <img class="default-img" src="${appConfig.imageBaseUrl}/assets/images/product/product-26.jpg" alt="">
                                        <img class="hover-img" src="${appConfig.imageBaseUrl}/assets/images/product/product-26-2.jpg" alt="">
                                    </a>
                                </div>
                                <div class="product-action-1">
                                    <button onclick="handleAddToCart('${cardPinType.id}', '${cardPinType.name}', '${cardPinType.rate}', '${1}', '${cardPinType.id}')" aria-label="Add To Cart"><i class="far fa-shopping-cart"></i></button>
                                    <button aria-label="Add To Wishlist"><i class="far fa-heart"></i></button>
                                    <button aria-label="Compare"><i class="far fa-signal"></i></button>
                                </div>
                                <div class="product-badges product-badges-position product-badges-mrg">
                                    <span class=" red">Sale</span>
                                </div>
                            </div>
                            <div class="product-content-wrap">
                                <div class="product-category">
                                    <a href="${vendorUrl}">${cardPinType.cardPinVendorName}</a>
                                </div>
                                <h2><a href="${detailsUrl}">${cardPinType.name}</a></h2>
                                <div class="product-price">
                                    <span class="new-price">₦${cardPinType.rate}</span>
                                    <span class="old-price"></span>
                                </div>
                            </div>
                        </div>
                    </div>`;
    });
    document.getElementById(elementId).innerHTML = content;
}


function initSlickSlider(elementId) {
    $(`#${elementId}`).slick({
        slidesToShow: 4,
        slidesToScroll: 1,
        fade: false,
        loop: true,
        dots: false,
        arrows: true,
        prevArrow: '<span class="pro-icon-1-prev"><i class="far fa-angle-left"></i></span>',
        nextArrow: '<span class="pro-icon-1-next"><i class="far fa-angle-right"></i></span>',
        responsive: [
            {
                breakpoint: 1199,
                settings: {
                    slidesToShow: 3,
                }
            },
            {
                breakpoint: 991,
                settings: {
                    slidesToShow: 2,
                }
            },
            {
                breakpoint: 767,
                settings: {
                    slidesToShow: 2,
                }
            },
            {
                breakpoint: 575,
                settings: {
                    slidesToShow: 1,
                }
            }
        ]
    });
}


async function handleLoginForm(returnUrl) {
    let form = document.getElementById('loginForm');
    form.addEventListener('submit', async e => {
        e.preventDefault();
        let submitButton = $('#loginSubmit');
        submitButton.attr('disabled', 'disabled');
        const email = $('#loginForm input[name=email]').val();
        const password = $('#loginForm input[name=password]').val();
        if (!email || !password) {
            notifyDataRequired('email and password is required');
        } else {
            await login(email, password, returnUrl);
        }
        submitButton.removeAttr('disabled');
        if (returnUrl) {
            window.location.href = returnUrl;
        } else {
            window.location.href = appConfig.appBaseUrl;
        }
    });
}

async function handleCartLoginForm() {
    let form = document.getElementById('cartLoginForm');
    form.addEventListener('submit', async e => {
        e.preventDefault();
        let submitButton = $('#cartLoginSubmit');
        submitButton.attr('disabled', 'disabled');
        const email = $('#cartLoginForm input[name=username]').val();
        const password = $('#cartLoginForm input[name=password]').val();
        if (!email || !password) {
            notifyDataRequired('email and password is required');
        } else {
            await login(email, password);
        }
        submitButton.removeAttr('disabled');
        updateCartPageDisplay();
    });
}

async function handleRegisterForm() {
    let form = document.getElementById('registerForm');
    form.addEventListener('submit', async e => {
        e.preventDefault();
        let submitButton = $('#registerSubmit');
        submitButton.attr('disabled', 'disabled');
        const email = $('#registerForm input[name=email]').val();
        const password = $('#registerForm input[name=password]').val();
        const firstName = $('#registerForm input[name=firstname]').val();
        const lastName = $('#registerForm input[name=lastname]').val();
        const phone = $('#registerForm input[name=phone]').val();
        const userType = parseInt($('#registerForm select[name=usertype]').val());
        const merchantCode = $('#registerForm input[name=merchantcode]').val();
        const businessName = $('#registerForm input[name=businessname]').val();
        if (!email || !password || !firstName || !lastName || !phone || !userType) {
            notifyDataRequired('Kindly complete the form correctly.');
        }
        else {
            const registrationInfo = {
                email, password, phone, firstName, lastName, userType, merchantCode, businessName
            }
            await register(registrationInfo);
        }
        submitButton.removeAttr('disabled');
    });
}

function updateUserTypeSelection(userType) {
    if (userType == 1) {
        $('#registerForm input[name=merchantcode]').removeAttr('required');
        $('#registerForm input[name=businessname]').removeAttr('required');
        $('#merchantcode').hide();
        $('#businessname').hide();
    }
    else {
        $('#merchantcode').show();
        $('#businessname').show();
        $('#registerForm input[name=merchantcode]').attr('required', true);
        $('#registerForm input[name=businessname]').attr('required', true);
    }
}


function handleAddToCart(id, name, price, quantity, image) {
    quantity = parseInt(quantity);
    price = parseFloat(price);
    const cartItem = { id, price, quantity, name, image };
    addToCart(cartItem);
    updateCartInfoDisplay(cartConfig.cartItemsId);
}

function handleRemoveFromCart(id) {
    removeCartItem(id);
    updateCartInfoDisplay(cartConfig.cartItemsId);
    updateCartPageDisplay(cartConfig.cartItemsTableId);
}


function handleClearCart() {
    clearCart();
    updateCartPageDisplay(cartConfig.cartItemsTableId);
}
