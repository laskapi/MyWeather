

$(function () {

    $(".js-example-basic-single").select2({
        minimumResultsForSearch: 2,
        width: 'resolve',
       

    });
});

/*
window.onload = function () {
    var select = document.getElementById('select_city');
    update(select.options[select.selectedIndex].value);
}*/

function update(value) {

    fetch("/Home/GetReport", {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify({ id: value })
    })
        .then(response => response.json())
        .then(json => {
            document.getElementById("report_icon_id").src = json.icon;
            document.getElementById("report_desc_id").innerText = json.description;
            document.getElementById("report_temp_id").innerText = json.temp;
            document.getElementById("report_humid_id").innerText = json.humidity;
            document.getElementById("report_speed_id").innerText = json.speed;
            document.getElementById("report_deg_id").innerText = json.deg;

        });
}



//-------------------------
// Unused because of flickering on icon upload
//-------------------------
function update_with_PartialView(value) {

    fetch("/Home/_WeatherPartial", {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify({ id: value })
    })
        .then(response => response.text())
        .then(html => {
            document.getElementById("weather_partial").innerHTML = html;
        });

}

