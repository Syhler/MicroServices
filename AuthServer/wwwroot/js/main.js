
(function ($) {
    "use strict";

    
    /*==================================================================
    [ Validate ]*/
    const input = $('.validate-input input');

    $('.validate-form').on('submit',function(){
        let check = true;

        console.log(input.length)
        
        for(let i=0; i<input.length; i++) {
            if(validate(input[i]) === false){
                showValidate(input[i]);
                check=false;
            }
        }
        
        console.log(check)

        return check;
    });


    $('.validate-form input').each(function(){
        $(this).focus(function(){
           hideValidate(this);
        });
    });

    function validate (input) {
        if($(input).attr('type') === 'email' || $(input).attr('name') === 'email') {
            if($(input).val().trim().match(/^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{1,5}|[0-9]{1,3})(\]?)$/) == null) {
                return false;
            }
        }
        else if($(input).attr("name") === "confirmPassword")
        {
            const password = $("#password").val()
            console.log(password)
            if ($(input).val() !== password)
            {
                return false;
            }
        }
        else if($(input).attr("name") === "confirmEmail")
        {
            const email = $("#email").val()
            console.log(email)
            if ($(input).val() !== email)
            {
                return false;
            }
        }
        else {
            if($(input).val().trim() === ''){
                return false;
            }
        }
    }

    function showValidate(input) {
        const thisAlert = $(input).parent();

        $(thisAlert).addClass('alert-validate');
    }

    function hideValidate(input) {
        const thisAlert = $(input).parent();

        $(thisAlert).removeClass('alert-validate');
    }
    
    

})(jQuery);