// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const uf = $("select#Uf");
const cityInput = $('input#City');
const cityNameInput = $('input#CityName');
const cityLoading = document.querySelector('div#loadingCity.autocomplete-feedback');

const streetInput = $('input#Street');
const streetNameInput = $('input#StreetName');
const streetLoading = document.querySelector('div#loadingStreet.autocomplete-feedback');


if (cityInput != null) {
    cityInput.autocomplete({
        autoFocus: false,
        source: (request, response) => {
            if (uf.val() == "") {
                cityInput.val("");
                cityNameInput.val("");
                var result = [
                    {
                        label: 'É necessário selecionar uma UF primeiro',
                        value: ''
                    }
                ];
                response(result);
            }
            else {
                fetch(`api/filladdress/autocompletecity?uf=${uf.val()}&query=${request.term}`)
                    .then(resp => resp.json())
                    .then(data => {
                        cityNameInput.val("");
                        if (!data.length) {
                            var result = [
                                {
                                    label: 'Nenhum resultado encontrado',
                                    value: ''
                                }
                            ];
                            response(result);
                        }
                        else {
                            // normal response
                            response($.map(data, item => {
                                return {
                                    label: item,
                                    value: item
                                }
                            }));
                        }
                    })
            }
        },
        search: () => {
            cityLoading.style.display = 'flex';
        },
        response: () => {
            cityLoading.style.display = 'none';
        },
        select: (event, ui) => {
            cityInput.val(ui.item.value);
            cityNameInput.val(ui.item.value);
            event.preventDefault();
        },
        // focus: (event, ui) => {
        //     cityInput.val(ui.item.value);
        //     cityNameInput.val(ui.item.value);
        //     event.preventDefault();
        // },
    })
}


if (streetInput != null) {
    streetInput.autocomplete({
        autoFocus: false,
        source: (request, response) => {
            if (cityNameInput.val() == "") {
                streetInput.val("");
                streetNameInput.val("");
                var result = [
                    {
                        label: 'É necessário selecionar um logradouro primeiro',
                        value: ''
                    }
                ];
                response(result);
            }
            else {
                fetch(`api/filladdress/autocompletestreet?cityName=${cityNameInput.val()}&query=${request.term}`)
                    .then(resp => resp.json())
                    .then(data => {
                        streetNameInput.val("");
                        if (!data.length) {
                            var result = [
                                {
                                    label: 'Nenhum resultado encontrado',
                                    value: ''
                                }
                            ];
                            response(result);
                        }
                        else {
                            // normal response
                            response($.map(data, item => {
                                return {
                                    label: item,
                                    value: item
                                }
                            }));
                        }
                    })
            }
        },
        search: () => {
            streetLoading.style.display = 'flex';
        },
        response: () => {
            streetLoading.style.display = 'none';
        },
        select: (event, ui) => {
            streetInput.val(ui.item.value);
            streetNameInput.val(ui.item.value);
            event.preventDefault();
        },
        // focus: (event, ui) => {
        //     streetInput.val(ui.item.value);
        //     streetNameInput.val(ui.item.value);
        //     event.preventDefault();
        // },
    })
}

uf.on("change", () => {
    cityInput.val("");
    cityNameInput.val("");
    streetInput.val("");
    streetNameInput.val("");
});

cityInput.on("change", () => {
    streetInput.val("");
    streetNameInput.val("");
})