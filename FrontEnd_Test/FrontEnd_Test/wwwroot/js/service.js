const login_section = document.getElementById('login_section');
const transaction_section = document.getElementById("transaction_section");
const base_url = 'http://localhost:5045';
window.onload = function () {
    isTokenValid();//Cel token apakah valid atau tidak
    populatelocation();//Populate dropdown location
};

//fungsi untuk handle login
const login = () => {
    const username = document.getElementById('username').value;
    const password = document.getElementById('password').value;
    loginUser(username, password);
}

// Fungsi untuk menangani pengiriman data ke API
const submitForm = () => {
    // Mengambil nilai dari setiap input
    isTokenValid();
    const agreementNumber = document.getElementById("agreementNumber").value;
    const branchID = document.getElementById("branchID").value;
    const noBPKB = document.getElementById("noBPKB").value;
    const tanggalBPKBIn = document.getElementById("tanggalBPKBIn").value;
    const tanggalBPKB = document.getElementById("tanggalBPKB").value;
    const noFaktur = document.getElementById("noFaktur").value;
    const tanggalFaktur = document.getElementById("tanggalFaktur").value;
    const nomorPolisi = document.getElementById("nomorPolisi").value;
    const lokasiPenyimpanan = document.getElementById("lokasiPenyimpanan").value;

    if (!agreementNumber) return alert("Agreement Number must be filled");
    if (!lokasiPenyimpanan) return alert("lokasi Penyimpanan must be select");

    //Mapping object
    const formData = {
        agreementNumber: agreementNumber,
        branchID: branchID,
        noBPKB: noBPKB,
        tanggalBPKBIn: !tanggalBPKBIn ? null : tanggalBPKBIn,
        tanggalBPKB: !tanggalBPKB ? null : tanggalBPKB,
        noFaktur: noFaktur,
        tanggalFaktur: !tanggalFaktur ? null : tanggalFaktur,
        nomorPolisi: nomorPolisi,
        lokasiPenyimpanan: lokasiPenyimpanan,
        user: getJWTUser()
    };
    request('/Transaction/Submit', formData, 'POST', handleSubmitRequest, populateData = (data) => { })
}

//Fungsi untuk isi data ke dropdown location
const populateDropdown = (data) => {
    const selectElement = document.getElementById('lokasiPenyimpanan');
    selectElement.innerHTML = '';
    const defaultOption = document.createElement('option');
    defaultOption.value = '';
    defaultOption.text = 'Silakan pilih lokasi';
    selectElement.appendChild(defaultOption);
    data.forEach(location => {
        const option = document.createElement('option');
        option.value = location.locationId;
        option.textContent = location.locationName;
        selectElement.appendChild(option);
    });
}

// Fungsi untuk populate data location
const populatelocation = () => {
    request('/location/GetLocation', null, 'GET', serializeJson, populateDropdown);
}

//fungsi untuk handle login
const loginUser = (username, password) => {
    const data = {
        username: username,
        password: password
    };
    request('/Session/Auth', data, 'POST', handleUserLogin, null);
}


// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
