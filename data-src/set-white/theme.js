document.addEventListener("DOMContentLoaded", function(event) {
    var bt = document.getElementById("t");
    var btx = document.getElementById("btn-ls-th");
    var white = document.getElementById("white-th");
    var orange = document.getElementById("orange-th");
    var purple = document.getElementById("purple-th");
    var black = document.getElementById("black-th");

    var b = "2px solid #000";
    var sl = "2px solid green";
    var ul1 = document.getElementById("ul-2");
    event.preventDefault();
    if (orange.checked == true) {
        white.checked = false;
        purple.checked == false;
        black.checked = false;
    } else if (purple.checked == true) {
        white.checked = false;
        orange.checked == false;
        black.checked = false;

    } else if (black.checked == true) {
        white.checked = false;
        orange.checked == false;
        purple.checked = false;
    } else {
        white.checked = true;
        purple.checked = false;
        orange.checked == false;
        black.checked = false;
    }
    if (orange.checked == false && white.checked == false && black.checked == false) {
        purple.checked = true;
    } else if (purple.checked == false && white.checked == false && black.checked == false) {
        orange.checked = true;
    } else if (purple.checked == false && white.checked == false && orange.checked == false) {
        black.checked = true;
    } else {
        white.checked = true;
        purple.checked = false;
        orange.checked == false;
        black.checked == false
    }
    white.addEventListener('click', () => {
        orange.checked = false;
        purple.checked = false;
        black.checked == false
        event.preventDefault();
        location.reload();
    });
    orange.addEventListener('click', () => {
        white.checked = false;
        purple.checked = false;
        black.checked == false
        event.preventDefault();
        location.reload();
    });
    purple.addEventListener('click', () => {
        white.checked = false;
        orange.checked = false;
        black.checked == false
        event.preventDefault();
        location.reload();
    });
    black.addEventListener('click', () => {
        white.checked = false;
        orange.checked = false;
        purple.checked = false;

        event.preventDefault();
        location.reload();
    });
    bt.addEventListener('click', () => {
        if (ul1.style.display == "block") ul1.style.display = "none";
        else ul1.style.display = "block";
    });

    btx.addEventListener('click', () => { ul1.style.display = "none"; });
});
var body = document.body;
var theme = document.getElementById("img-ul-2-sl");

document.getElementById('orange-th').addEventListener('change', function() {
    // Kiểm tra nếu checkbox được kiểm tra
    if (this.checked) {
        // Thêm lớp orange-mode cho body
        body.classList.add('orange-mode');
        localStorage.setItem('orangeMode', 'enabled');
        body.classList.remove('purple-mode');
        localStorage.removeItem('purpleMode');
        body.classList.remove('black-mode');
        localStorage.removeItem('blackMode');
        theme.src = "background/orange-theme.webp";
    } else {
        // Xóa lớp orange-mode khỏi body
        body.classList.remove('orange-mode');
        localStorage.removeItem('orangeMode');
        theme.src = "background/white-theme.webp";
    }
});
document.getElementById('black-th').addEventListener('change', function() {
    if (this.checked) {
        body.classList.add('black-mode');
        localStorage.setItem('blackMode', 'enabled');
        body.classList.remove('orange-mode');
        localStorage.removeItem('orangeMode');
        body.classList.remove('purple-mode');
        localStorage.removeItem('purpleMode');
        theme.src = "background/black-theme.webp";
    } else {
        body.classList.remove('black-mode');
        localStorage.removeItem('blackMode');
        theme.src = "background/white-theme.webp";
    }
});
document.getElementById('purple-th').addEventListener('change', function() {
    if (this.checked) {
        body.classList.add('purple-mode');
        localStorage.setItem('purpleMode', 'enabled');
        body.classList.remove('orange-mode');
        localStorage.removeItem('orangeMode');
        body.classList.remove('black-mode');
        localStorage.removeItem('blackMode');
        theme.src = "background/purple-theme.webp";
    } else {
        // Xóa lớp orange-mode khỏi body
        body.classList.remove('purple-mode');
        localStorage.removeItem('purpleMode');
        theme.src = "background/white-theme.webp";
    }
});
document.getElementById('white-th').addEventListener('change', function() {
    if (this.checked) {
        // Xóa lớp orange-mode khỏi body
        body.classList.remove('orange-mode');
        localStorage.removeItem('orangeMode');
        body.classList.remove('purple-mode');
        localStorage.removeItem('purpleMode');
        body.classList.remove('black-mode');
        localStorage.removeItem('blackMode');
        theme.src = "background/white-theme.webp";


    }
});

document.addEventListener("DOMContentLoaded", function() {
    var orangeModeStatus = localStorage.getItem('orangeMode');
    var purpleModeStatus = localStorage.getItem('purpleMode');
    var blackModeStatus = localStorage.getItem('blackMode');

    // Nếu orangeModeStatus là "enabled", thêm lớp orange-mode cho body và kiểm tra checkbox
    if (orangeModeStatus === 'enabled') {
        body.classList.add('orange-mode');
        document.getElementById('orange-th').checked = true;
        document.getElementById('purple-th').checked = false;
        document.getElementById('white-th').checked = false;
        document.getElementById('black-th').checked = false;

        theme.src = "background/orange-theme.webp";
    }
    if (purpleModeStatus === 'enabled') {
        body.classList.add('purple-mode');
        document.getElementById('purple-th').checked = true;
        document.getElementById('orange-th').checked = false;
        document.getElementById('white-th').checked = false;
        document.getElementById('black-th').checked = false;

        theme.src = "background/purple-theme.webp";
    }
    if (blackModeStatus === 'enabled') {
        body.classList.add('black-mode');
        document.getElementById('black-th').checked = true;
        document.getElementById('orange-th').checked = false;
        document.getElementById('purple-th').checked = false;
        document.getElementById('white-th').checked = false;
        theme.src = "background/black-theme.webp";

    }
    document.addEventListener("contextmenu", function(event) {
        event.preventDefault();
    });

    // document.onkeydown = function(e) {
    //     if (event.keyCode == 123 || (e.ctrlKey && e.keyCode == 85)) {
    //         // Chặn sự kiện mặc định
    //         event.preventDefault();

    //         // Hiển thị thông báo
    //         alert("Bạn không thể xài chức năng này!");
    //     }
    // };
});
document.getElementById('orangeModeCheckbox-footer').addEventListener('change', function() {
    // Lấy thẻ body
    var body = document.body;

    // Kiểm tra nếu checkbox được kiểm tra
    if (this.checked) {
        // Thêm lớp orange-mode cho body
        body.classList.add('orange-mode');
        localStorage.setItem('orangeMode', 'enabled');

    } else {
        // Xóa lớp orange-mode khỏi body
        body.classList.remove('orange-mode');
        localStorage.removeItem('orangeMode');

    }
});
document.addEventListener("DOMContentLoaded", function() {
    var orangeModeStatus = localStorage.getItem('orangeMode');
    var purpleModeStatus = localStorage.getItem('purpleMode');

    // Lấy thẻ body
    var body = document.body;

    // Nếu orangeModeStatus là "enabled", thêm lớp orange-mode cho body và kiểm tra checkbox
    if (orangeModeStatus === 'enabled') {
        body.classList.add('orange-mode');
        document.getElementById('orangeModeCheckbox-footer').checked = true;
    }
    document.addEventListener("contextmenu", function(event) {
        event.preventDefault();
    });

    // document.onkeydown = function(e) {
    //     if (event.keyCode == 123 || (e.ctrlKey && e.keyCode == 85)) {
    //         // Chặn sự kiện mặc định
    //         event.preventDefault();

    //         // Hiển thị thông báo
    //         alert("Bạn không thể xài chức năng này!");
    //     }
    // };
});