let characters = document.querySelectorAll(".character");
let container_details_character = document.querySelector(".container-details-character");

characters.forEach(character => {
    character.addEventListener("click", () => {

        getCharacter(character);
    });
})

function getCharacter(div) {
    let name = div.getAttribute("name");
    let status = div.getAttribute("status");
    let image = div.getAttribute("image");
    let gender = div.getAttribute("gender");
    let species = div.getAttribute("species");
    let type = div.getAttribute("type");
    let created = div.getAttribute("created");
    let origin = div.getAttribute("origin");
    let location = div.getAttribute("location");

    container_details_character.innerHTML = `
          <div class="character-details">
            <button class="leave-character">Quitar</button>
            <div class="image">
                <img src="${image}" alt="">
            </div>
            <div class="content">
                <div class="title">
                    <h4>${name}</h4>
                </div>
                <ul class="info">
                    <li>${status}</li>
                    <li>${gender}</li>
                    <li>${species}</li >
                    <li>${type}</li>
                    <li>${created}</li>
                    <li>${origin}</li>
                    <li>${location}</li>
                </ul>
            </div>
        </div>
    `
    container_details_character.style.display = "block";
    let leave_character = document.querySelector(".leave-character");
    leaveDetails(leave_character);
}

function leaveDetails(button) {
    button.addEventListener("click", () => {
        container_details_character.style.display = "none";
        console.log("saliendo de detalles")
    })
}
