// Fungsi untuk mereset form
const resetForm = () => {
    document.getElementById("transaction_form").reset();
    document.getElementById("transaction_form2").reset();
}

//Fungsi untuk show trasaction
const showTransactionPage = () => {
    transaction_section.style.display = 'block';
    login_section.style.display = 'none';
}

//Fungsi untuk hide trasaction
const hideTransactionpage = () => {
    transaction_section.style.display = 'none';
    login_section.style.display = 'block';
}

const handleSubmitRequest = (response) => {
    if (!response.ok) {
        alert("Failed to save data");
    }
    else {
        alert("Success save data");
        resetForm();
    }
}

const handleUserLogin = (response, callback) => {
    if (!response.ok) alert("Username or Password Invalid")
    else
        return response.json().then(data => {
            localStorage.setItem('token', data.token);//setelah JSON di-serialisasi, store ke local storage
            showTransactionPage();
        });
}

//fungsi untuk cek apakah token valid
const isTokenValid = () => {
    const token = localStorage.getItem('token');
    if (!token) {
        hideTransactionpage();
    }
    else {
        const tokenPayload = JSON.parse(atob(token.split('.')[1]));
        const tokenExpiration = new Date(tokenPayload.exp * 1000);
        const currentDate = new Date();
        if (currentDate < tokenExpiration) {
            showTransactionPage();
        } else {
            hideTransactionpage();
        }
    }
}

const serializeJson = (response, callback) => {
    return response.json().then(data => {
        callback(data);
    });
}

const getJWTUser = () => {
    const token = localStorage.getItem('token');
    const base64Url = token.split('.')[1];
    const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    const payload = JSON.parse(atob(base64));
    return payload.unique_name;
}

const request = (endpoint, data, method, callback, populateData) => {
    const jsonData = JSON.stringify(data);

    const requestOptions = {
        method: method,
        headers: {
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${localStorage.getItem('token')}`
        },
        body: method === 'GET' ? null : jsonData // Mengatur body menjadi null untuk permintaan GET
    };

    fetch(base_url + endpoint, requestOptions)
        .then(response => {
            callback(response, populateData);
        })
        .catch(error => {
            console.error('Error:', error);
        });
};