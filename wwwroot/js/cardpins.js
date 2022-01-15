
async function getCardPinVendors() {
    const response = await axios.get('/cardpinvendors');
    return response.data.data;
}

async function getCardPinVendor(cardPinVendorId) {
    const response = await axios.get(`/cardpinvendors/${cardPinVendorId}`);
    return response.data.data;
}

async function getCardPinTypes() {
    const response = await axios.get('/cardpintypes');
    return response.data.data;
}

async function getCardPinType(cardPinTypeId) {
    const response = await axios.get(`/cardpintypes/${cardPinTypeId}`);
    return response.data.data;
}