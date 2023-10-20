let characters = document.querySelectorAll(".character");

characters.forEach(character => {
    character.addEventListener("click", () => {

        getCharacter(character);
    });
})


function getCharacter(div) {
    let name = div.getAttribute("name");
    let status = div.getAttribute("status");
    let gender = div.getAttribute("gender");
    let species = div.getAttribute("species");
    let type = div.getAttribute("type");
    let created = div.getAttribute("created");
    let origin = div.getAttribute("origin");
    let location = div.getAttribute("location");
    console.log(name);
    console.log(status);
    console.log(gender);
    console.log(created);
}