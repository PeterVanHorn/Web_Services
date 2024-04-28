// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const currentDate = document.querySelector(".current-date"),
    daysTag = document.querySelector(".days"),
    prevNextIcon = document.querySelectorAll(".icons span");

let date = new Date();
currYear = date.getFullYear();
currMonth = date.getMonth();

const months = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];

const renderCalendar = () => {
    let firstDayofMonth = new Date(currYear, currMonth, 1).getDay(), // get first day of month
        lastDateofMonth = new Date(currYear, currMonth + 1, 0).getDate(), //get last date of month
        lastDayofMonth = new Date(currYear, currMonth, lastDateofMonth).getDay(), //get last day of month
    lastDateofLastMonth = new Date(currYear, currMonth, 0).getDate(); //get last date of previous month

    let liTag = "";

    for (let i = firstDayofMonth; i > 0; i--) { // create li of previous month last days
        liTag += `<li class="inactive">${lastDateofLastMonth - i + 1}</li>`;
    }

    //for (let i = 1; i <= lastDateofMonth; i++) { // create li of all current month days
    //    // add active class to li if the current day, month and year all match
    //    let isToday = i === date.getDate() && currMonth === new Date().getMonth()
    //        && currYear === new Date().getFullYear() ? "active" : "";
    //    liTag += `<li class="${isToday}">${i}</li>`;
    //}

    // experimental code for clicking on days to view their details page
    for (let i = 1; i <= lastDateofMonth; i++) {
        // Add unique IDs to each day element
        let monthFormatted = (currMonth + 1).toString().padStart(2, '0');
        let dayFormatted = i.toString().padStart(2, '0');
        let dayId = `day-${currYear}-${monthFormatted}-${dayFormatted}`;
        let isToday = i === date.getDate() && currMonth === new Date().getMonth()
            && currYear === new Date().getFullYear() ? "active" : "";
        liTag += `<li id="${dayId}" class="${isToday}">${i}</li>`;
    }

    for (let i = lastDayofMonth; i < 6; i++) { // create li of next month first days
        liTag += `<li class="inactive">${i - lastDayofMonth + 1}</li>`;
    }

    currentDate.innerText = `${months[currMonth]} ${currYear}`;
    daysTag.innerHTML = liTag;
}
renderCalendar();

prevNextIcon.forEach(icon => {
    icon.addEventListener("click", () => {
        currMonth = icon.id === "prev" ? currMonth - 1 : currMonth + 1;

        if (currMonth < 0 || currMonth > 11) {
            date = new Date(currYear, currMonth);
            currYear = date.getFullYear(); // update current year with new year
            currMonth = date.getMonth(); // update current month with new month
        }
        else { // else pass new date as date
            date = new Date();
        }
        renderCalendar();
    });
});

// Add click event listener to each day
document.querySelectorAll('.days li').forEach(day => {
    day.addEventListener('click', () => {
        // Extract the day, month, and year from the day ID
        let [_, year, month, dayOfMonth] = day.id.split('-');

        // Create a Date object representing the clicked date
        let clickedDate = `${year}-${month}-${dayOfMonth}`;

        // Send an AJAX request to check for the existence of the day object
        fetch('/Calendar?handler=OnPostCheckDayExistence', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({ id: clickedDate }),
        })
            .then(response => response.json())
            .then(data => {
                if (data.exists) {
                    // If the day object exists, navigate to its details page
                    window.location.href = `/Days/Details?id=${data.dayId}`;
                } else {
                    // If the day object doesn't exist, create it (not implemented here) and navigate to its details page
                    // You can implement the creation logic here
                    // For now, just redirect to a placeholder URL
                    window.location.href = `/Days/Create?id=${clickedDate}`;
                }
            })
            .catch(error => {
                console.error('Error:', error);
            });

        //// Redirect to details page with the selected date information
        //window.location.href = `/Days/Details?id=${year}-${month}-${dayOfMonth}`;
    });
});