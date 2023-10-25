let characters = document.querySelectorAll(".character");
let menuHamburger = document.querySelector(".menu");
let navLinks = document.querySelector(".nav-links");
let container_details_character = document.querySelector(".container-details-character");

characters.forEach(character => {
    character.addEventListener("click", () => {

        getCharacter(character);
    });
})

menuHamburger.addEventListener('click', () => {
    navLinks.classList.toggle('mobile-menu');
});

function getCharacter(div) {
    let name = div.getAttribute("name");
    let status = div.getAttribute("status");
    let image = div.getAttribute("image");
    let gender = div.getAttribute("gender");
    let species = div.getAttribute("species");
    let type = div.getAttribute("type");
    let origin = div.getAttribute("origin");
    let location = div.getAttribute("location");

    container_details_character.innerHTML = `
          <div class="character-details">
            <div class="details">
                <div class="image">
                    <img src="${image}" alt="">
                </div>
                <div class="content">
                <div class="header"">
                    <h4>${name}</h4>
                    <button class="leave-character"><img src="/assets/icons/back.png"/></button>
                </div>
                    <ul class="info">
                        <li><span><b>Status: </b></span>${status}</li>
                        <li><span><b>Gender: </b></span>${gender}</li>
                        <li><span><b>Species: </b></span>${species}</li >
                        <li><span><b>Type: </b></span>${type}</li>
                        <li><span><b>Origin: </b></span>${origin}</li>
                        <li><span><b>Location: </b></span>${location}</li>
                    </ul>
                </div>
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
    })
}
