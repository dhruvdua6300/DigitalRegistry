// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

new Chart(document.getElementById("pie-chart"), {
    type: 'pie',
    data: {
        labels: ["agriculture", "air travel", "arts", "banking", "benefits", "better business bureaus", "biology", "business", "business development", "career", "cars", "challenges", "charities", "child care", "children", "citizenship", "college", "commerce", "community", "community development", "complaints", "conservation", "consumer credit", "consumer safety", "consumers"],
        datasets: [{
            label: "Population (millions)",
            backgroundColor: ["#3e95cd", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850", "#95E75D", "#57A720", "#20A78A", "#8E12CD", "#03AEB4", "#1B03B4", "#CD5CF1", "#340842", "#B71DCC", "#CC1D35", "#0B4903", "#37E3DB", "#E74F11", "#0C5762", "#B263E2", "#1E2F98", "#A872BF", "#5B3136", "#878718", "#2DC3C3", "#171089","#310433"],
            data: [28, 0, 12, 3, 8, 0, 59, 89, 3, 8, 3, 1, 0, 0, 16, 0, 0, 0, 5, 4, 0, 85, 0, 5, 5]
        }]
    },
    options: {
        title: {
            display: true,
            text: 'Social Media Applications By Categories'
        }
    }
});