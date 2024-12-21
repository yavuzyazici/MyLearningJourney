/**
* PHP Email Form Validation - v3.9
* URL: https://bootstrapmade.com/php-email-form/
* Author: BootstrapMade.com
*/
(function () {
    "use strict";

    let forms = document.querySelectorAll('.php-email-form');

    forms.forEach(function (e) {
        e.addEventListener('submit', function (event) {
            event.preventDefault();

            let thisForm = this;

            let action = thisForm.getAttribute('action');
            let recaptcha = thisForm.getAttribute('data-recaptcha-site-key');

            if (!action) {
                displayError(thisForm, 'The form action property is not set!');
                return;
            }
            thisForm.querySelector('.loading').classList.add('d-block');
            thisForm.querySelector('.error-message').classList.remove('d-block');
            thisForm.querySelector('.sent-message').classList.remove('d-block');

            let formData = new FormData(thisForm);
            php_email_form_submit(thisForm, action, formData);
        });
    });

    function php_email_form_submit(thisForm, action, formData) {
        fetch(action, {
            method: 'POST',
            body: formData,
            headers: { 'X-Requested-With': 'XMLHttpRequest' }
        })
            .then(response => {
                if (response.ok) {
                    return response.text();
                } else {
                    return response.text();
                }
            })
            .then(data => {
                thisForm.querySelector('.loading').classList.remove('d-block');
                if (data.trim().includes("successfully")) {
                    thisForm.querySelector('.sent-message').classList.add('d-block');
                    thisForm.querySelector('.sent-message').innerHTML = data;
                    thisForm.reset();
                } else {
                    thisForm.querySelector('.error-message').classList.add('d-block');
                    thisForm.querySelector('.error-message').innerHTML = data;
                }
            })
            .catch((error) => {
                displayError(thisForm, error);
            });
    }

    function displayError(thisForm, error) {
        thisForm.querySelector('.loading').classList.remove('d-block');
        thisForm.querySelector('.error-message').innerHTML = error.replace("Error:", "");
        thisForm.querySelector('.error-message').classList.add('d-block');
    }

})();
