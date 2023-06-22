let addedPositions = 0;

const addPositionButton = document.getElementById('addPositionButton');
addPositionButton.addEventListener('click', handleAddPosition)

const positionsContainer = document.getElementById('positionsContainer');

function handleAddPosition()
{
    const itemId = addedPositions;

    if (addedPositions >= zones.length)
    {
        return;
    }

    var mainLabel = document.createElement('label');
    mainLabel.innerHTML = `Pozycja ${addedPositions + 1}`;
    mainLabel.className = 'form-label mt-3';
    positionsContainer.appendChild(mainLabel);

    zones.forEach(zone =>
    {
        var zoneFormCheck = document.createElement('div');
        zoneFormCheck.className = 'form-check';

        var formCheckInput = document.createElement('input');
        formCheckInput.className = 'form-check-input';
        formCheckInput.type = 'radio';
        formCheckInput.value = zone.number;
        formCheckInput.name = `Items[${itemId}].ZoneNumber`;
        formCheckInput.id = `zone-${itemId}-${zone.label}`;

        var formCheckLabel = document.createElement('label');
        formCheckLabel.htmlFor = `zone-${itemId}-${zone.label}`;
        formCheckLabel.innerHTML = `Strefa ${zone.label}`

        positionsContainer.appendChild(zoneFormCheck);

        zoneFormCheck.appendChild(formCheckInput);
        zoneFormCheck.appendChild(formCheckLabel);
    })

    var commentFormLabel = document.createElement('label');
    commentFormLabel.innerHTML = 'Komentarz:';
    commentFormLabel.className = 'form-label'

    var commentTextArea = document.createElement('textarea');
    commentTextArea.className = 'form-control'
    commentTextArea.name = `Items[${itemId}].Comment`;

    positionsContainer.appendChild(commentFormLabel);
    positionsContainer.appendChild(commentTextArea);


    addedPositions += 1;

    if (addedPositions == zones.length)
    {
        addPositionButton.disabled = true;
    }
}