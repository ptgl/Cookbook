var $j = jQuery.noConflict(); $j(document).ready(function () {
    "use strict"; dropDownMenu(); setDropDownMenuPosition(); dropDownMenu2(); selectMenu(); initAccordion(); initAccordionFullWidth(); initProgressBars(); initCounter(); initTabs(); initMessages(); setFooterHeight(); initFlexSlider(); backButtonInterval(); backToTop(); fitVideo(); accordionFullWidth(); topAreaLine(); viewPort(); initParallax(parallax_speed); parallaxPager(); selectBox(); initFadeDownEffect(); initDoughnutChart(); initToCounter(); placeholderReplace(); addPlaceholderSearchWidget(); prettyPhoto(); loadMore(); initAccordionContentLink(); languageMenu()
});
$j(window).load(function () {
    "use strict";
    $j('header').removeClass('hide_background');
    $j('.touch .main_menu li:has(div.second)').doubleTapToGo();
    logo_height = $j('.logo img').height(); setLogoHeightOnLoad();
    checkLogOnSmallestSize();
    $j('.logo a').css('visibility', 'visible'); initProjects();
    initElements(); initBlog(); setSidebarBackgroundColor(); setBlogPortfolioListHeight(); initPortfolioSingleInfo()
});

$j(window).scroll(function () {
    "use strict";
    var scroll = $j(window).scrollTop();
    if ($j(window).width() > 768 && $j('.no_fixed').length === 0) { headerSize(scroll) }
});
$j(window).resize(function () {
    "use strict"; setBlogPortfolioListHeight(); accordionFullWidth(); topAreaLine(); setDropDownMenuPosition(); setSidebarBackgroundColor(); checkLogOnSmallestSize()
});
function dropDownMenu() {
    "use strict"; var menu_items = $j('.no-touch .drop_down > ul > li'); menu_items.each(function (i) { if ($j(menu_items[i]).find('.second').length > 0) { $j(menu_items[i]).data('original_height', $j(menu_items[i]).find('.second').height() + 'px'); $j(menu_items[i]).find('.second').hide(); $j(menu_items[i]).mouseenter(function () { $j(menu_items[i]).find('.second').css({ 'visibility': 'visible', 'height': '0px', 'opacity': '0', 'display': 'block' }); $j(menu_items[i]).find('.second').stop().animate({ 'height': $j(menu_items[i]).data('original_height'), opacity: 1 }, 400, function () { $j(menu_items[i]).find('.second').css('overflow', 'visible') }); dropDownMenuThirdLevel() }).mouseleave(function () { $j(menu_items[i]).find('.second').stop().animate({ 'height': '0px' }, 0, function () { $j(menu_items[i]).find('.second').css({ 'overflow': 'hidden', 'visivility': 'hidden', 'display': 'none' }) }) }) } })
}
function languageMenu() {
    "use strict"; var lang_item = $j('.header_right_widget #lang_sel > ul > li'); if ($j(lang_item).find('ul').length > 0) { $j(lang_item).data('original_height', $j(lang_item).find('ul').height() + 'px'); $j(lang_item).find('ul').hide(); $j(lang_item).mouseenter(function () { $j(lang_item).find('ul').css({ 'visibility': 'visible', 'height': '0px', 'opacity': '0', 'display': 'block' }); $j(lang_item).find('ul').stop().animate({ 'height': $j(lang_item).data('original_height'), opacity: 1 }, 400, function () { $j(lang_item).find('.second').css('overflow', 'visible') }) }).mouseleave(function () { $j(lang_item).find('ul').stop().animate({ 'height': '0px' }, 0, function () { $j(lang_item).find('ul').css({ 'overflow': 'hidden', 'visivility': 'hidden', 'display': 'none' }) }) }) }
}
function setDropDownMenuPosition() {
    "use strict"; var menu_items = $j('.drop_down > ul > li'); menu_items.each(function (i) { var browser_width = $j(window).width(); var menu_item_position = $j(menu_items[i]).offset().left; var sub_menu_width = $j('.drop_down .second .inner2 ul').width(); var u = browser_width - menu_item_position + 30; var m; if ($j(menu_items[i]).find('li.sub').length > 0) { m = browser_width - menu_item_position - sub_menu_width + 30 } if (u < sub_menu_width || m < sub_menu_width) { $j(menu_items[i]).find('.second').addClass('right'); $j(menu_items[i]).find('.second .inner .inner2 ul').addClass('right') } })
}
function dropDownMenu2() {
    "use strict"; var widget_width = $j('.header_right_widget').width(); var margin = -1000 - widget_width; $j('.drop_down2 .second').css({ 'margin-left': margin, 'margin-right': margin }); $j('.no-touch .drop_down2 > ul > li').each(function () { var height = $j(this).find('.second').height(); $j(this).mouseenter(function () { $j(this).find('.second').height(0); $j(this).find('.second').css({ 'visibility': 'visible', 'z-index': '100' }); $j(this).find('.second').stop().animate({ height: height + 20 }, 400) }).mouseleave(function () { $j(this).find('.second').css('z-index', '90'); $j(this).find('.second').stop().animate({ height: 0 }, 400, function () { $j(this).css('visibility', 'hidden'); $j(this).height(0) }) }) })
}
function dropDownMenuThirdLevel() {
    "use strict"; var menu_items2 = $j('.no-touch .drop_down ul li > .second > .inner > .inner2 > ul > li'); menu_items2.each(function (i) { if ($j(menu_items2[i]).find('ul').length > 0) { var sum = 0; $j(menu_items2[i]).find('ul li').each(function () { sum += $j(this).height() }); $j(menu_items2[i]).data('original_height', sum + 'px'); var size2 = $j(menu_items2[i]).find('ul > li').size() * 10 + 100; $j(menu_items2[i]).mouseenter(function () { $j(menu_items2[i]).find('ul').css({ 'visibility': 'visible', 'height': '0px', 'opacity': '0', 'display': 'block', 'padding': '10px 0' }); $j(menu_items2[i]).find('ul').stop().animate({ 'height': $j(menu_items2[i]).data('original_height'), opacity: 1 }, size2, function () { $j(menu_items2[i]).find('ul').css('overflow', 'visible') }) }).mouseleave(function () { $j(menu_items2[i]).find('ul').stop().animate({ 'height': '0px' }, 0, function () { $j(menu_items2[i]).find('ul').css({ 'overflow': 'hidden', 'padding': '0' }); $j(menu_items2[i]).find('.second').css('visivility', 'hidden') }) }) } })
}
function selectMenu() {
    "use strict"; var $menu_select = $j("<div class='select'><ul></ul></div>"); $menu_select.appendTo(".selectnav"); if ($j(".main_menu").hasClass('drop_down')) { $j(".main_menu ul li a").each(function () { var menu_url = $j(this).attr("href"); var menu_text = $j(this).text(); if ($j(this).parents("li").length === 2) { menu_text = "&nbsp;&nbsp;&nbsp;" + menu_text } if ($j(this).parents("li").length === 3) { menu_text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + menu_text } if ($j(this).parents("li").length > 3) { menu_text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + menu_text } var li = $j("<li />"); var link = $j("<a />", { "href": menu_url, "html": menu_text }); link.appendTo(li); li.appendTo($menu_select.find('ul')) }) } else if ($j(".main_menu").hasClass('drop_down2')) { $j(".main_menu ul li a").each(function () { var menu_url = $j(this).attr("href"); var menu_text = $j(this).text(); if ($j(this).parents("div.mc").length === 1) { menu_text = "&nbsp;&nbsp;&nbsp;" + menu_text } if ($j(this).hasClass('sub')) { menu_text = "&nbsp;&nbsp;&nbsp;&nbsp;" + menu_text } var li = $j("<li />"); var link = $j("<a />", { "href": menu_url, "html": menu_text }); link.appendTo(li); li.appendTo($menu_select.find('ul')) }) } $j(".selectnav_button span").click(function () { if ($j(".select ul").is(":visible")) { $j(".select ul").slideUp() } else { $j(".select ul").slideDown() } }); $j(".selectnav ul li a").click(function () { $j(".select ul").slideUp() })
}
function initAccordionFullWidth() {
    "use strict"; $j(".accordion .accordion_inner").accordion({ animate: "swing", collapsible: true, active: false, icons: "", heightStyle: "content" }); $j('.accordion .accordion_inner').each(function () { $j(this).click(function () { if ($j(this).find('h4').hasClass('ui-state-active')) { $j(this).find('span.arrow').addClass('animate_arrow') } else { $j(this).find('span.arrow').removeClass('animate_arrow') } }) })
}
function initProjects() {
    "use strict"; $j('.filter_holder').each(function () { var filter_height = 0; $j(this).find('li.filter').each(function () { filter_height += $j(this).height() }); $j(this).on('click', function (data) { var $drop = $j(this), $bro = $drop.siblings('.hidden'); if (!$drop.hasClass('expanded')) { $drop.find('ul').css('z-index', '10'); $drop.find('ul').height(filter_height + 30); $drop.addClass('expanded'); var label = $drop.find('.label span'); label.text(label.attr('data-label')) } else { $drop.find('ul').height(30); $drop.removeClass('expanded'); var $selected = $j(data.target), ndx = $selected.index(); if ($j(data.target)[0].tagName === 'li') { $drop.find('.label span').text($(data.target).text()) } if ($bro.length) { $bro.find('option').removeAttr('selected').eq(ndx).attr('selected', 'selected').change() } } }) }); $j('.filter_holder .filter').on('click', function () { var $this = $j(this).text(); var dropLabels = $j('.filter_holder').find('.label span'); dropLabels.each(function () { $j(this).text($this) }) }); $j('.projects_holder').mixitup({ showOnLoad: 'all', transitionSpeed: 600, minHeight: 150 }); $j('.projects_type1 > .mix ').each(function () { $j(this).hoverdir() })
}
function resetFilter() { var label = $j('.filter_holder').find('.label span'); label.text(label.attr('data-label')); $j('.filter_holder').find('li.filter').removeClass('active') }

function initBlog() {
     "use strict"; $j('.blog_holder_inner').mixitup({ showOnLoad: 'all', transitionSpeed: 600, minHeight: 150 })
}

function setFooterHeight() {
     "use strict"; var maxHeight = Math.max.apply(null, $j(".footer_top .four_columns > div").map(function () { return $j(this).height() }).get()); $j('.footer_top .four_columns > div').css('min-height', maxHeight)
}

function setSidebarBackgroundColor() {
    "use strict"; var column_height1 = $j('.two_columns_66_33.background_color_sidebar > .column1').height(); $j('.two_columns_66_33.background_color_sidebar > .column2').css('min-height', column_height1); var column_height2 = $j('.two_columns_75_25.background_color_sidebar > .column1').height(); $j('.two_columns_75_25.background_color_sidebar > .column2').css('min-height', column_height2); var column_height3 = $j('.two_columns_33_66.background_color_sidebar > .column2').height(); $j('.two_columns_33_66.background_color_sidebar > .column1').css('min-height', column_height3); var column_height4 = $j('.two_columns_25_75.background_color_sidebar > .column2').height(); $j('.two_columns_25_75.background_color_sidebar > .column1').css('min-height', column_height4)
}
function initElements() { "use strict"; $j('.element_from_left').each(function () { $j(this).appear(function () { $j(this).addClass('element_from_left_on') }, { accX: 0, accY: -150 }) }); $j('.element_from_right').each(function () { $j(this).appear(function () { $j(this).addClass('element_from_right_on') }, { accX: 0, accY: -150 }) }); $j('.element_from_top').each(function () { $j(this).appear(function () { $j(this).addClass('element_from_top_on') }, { accX: 0, accY: -150 }) }); $j('.element_from_bottom').each(function () { $j(this).appear(function () { $j(this).addClass('element_from_bottom_on') }, { accX: 0, accY: -150 }) }); $j('.element_transform').each(function () { $j(this).appear(function () { $j(this).addClass('element_transform_on') }, { accX: 0, accY: -150 }) }) } function initFlexSlider() { "use strict"; $j('.flexslider').flexslider({ animationLoop: true, controlNav: false, useCSS: false, pauseOnAction: true, pauseOnHover: true, slideshow: true, animation: 'slides', animationSpeed: 600, slideshowSpeed: 8000, start: function () { setTimeout(function () { $j(".flexslider").fitVids() }, 100) } }); $j('.flex-direction-nav a').click(function (e) { e.preventDefault(); e.stopImmediatePropagation(); e.stopPropagation() }) } function setBlogPortfolioListHeight() { "use strict"; var max = Math.max.apply(null, $j(".blog_holder article.mix").map(function () { return $j(this).height() }).get()); $j(".blog_holder article.mix").each(function () { $j(this).height(max) }) } function initAccordion() { "use strict"; $j(".accordion").accordion({ animate: "swing", collapsible: true, active: false, icons: "", heightStyle: "content" }); $j(".toggle").addClass("accordion ui-accordion ui-accordion-icons ui-widget ui-helper-reset").find("h4").addClass("ui-accordion-header ui-helper-reset ui-state-default ui-corner-top ui-corner-bottom").hover(function () { $j(this).toggleClass("ui-state-hover") }).click(function () { $j(this).toggleClass("ui-accordion-header-active ui-state-active ui-state-default ui-corner-bottom").next().toggleClass("ui-accordion-content-active").slideToggle(200); return false }).next().addClass("ui-accordion-content ui-helper-reset ui-widget-content ui-corner-bottom").hide() } function initProgressBars() { "use strict"; $j('.progress_bars').each(function () { $j(this).appear(function () { $j(this).find('.progress_bar').each(function () { var percentage = $j(this).find('.progress_content').data('percentage'); $j(this).find('.progress_content').css('width', '0%'); $j(this).find('.progress_number').css('width', '0%'); $j(this).find('.progress_content').animate({ 'width': percentage + '%' }, 2000); $j(this).find('.progress_number').html(percentage + '%'); $j(this).find('.progress_number').animate({ 'width': '33px' }, 1800) }) }) }) } function initTabs() { "use strict"; var $tabsNav = $j('.tabs-nav'); var $tabsNavLis = $tabsNav.children('li'); $tabsNav.each(function () { var $this = $j(this); $this.next().children('.tab-content').stop(true, true).hide().first().show(); $this.children('li').first().addClass('active').stop(true, true).show() }); $tabsNavLis.on('click', function (e) { var $this = $j(this); $this.siblings().removeClass('active').end().addClass('active'); $this.parent().next().children('.tab-content').stop(true, true).hide().siblings($this.find('a').attr('href')).fadeIn(); e.preventDefault() }) } function initCounter() { "use strict"; $j('.counter').each(function () { $j(this).appear(function () { $j(this).absoluteCounter({ speed: 1500, fadeInDelay: 1000 }) }) }) } var $scrollHeight; function initPortfolioSingleInfo() { "use strict"; var $sidebar = $j(".portfolio_single_follow"); if ($j(".portfolio_single_follow").length > 0) { var offset = $sidebar.offset(); $scrollHeight = $j(".portfolio_container").height(); var $scrollOffset = $j(".portfolio_container").offset(); var $window = $j(window); var $menuLineHeight = parseInt($j('.main_menu > ul > li > a').css('line-height'), 10); $window.scroll(function () { if ($window.width() > 960) { if ($window.scrollTop() + $menuLineHeight + 3 > offset.top) { if ($window.scrollTop() + $menuLineHeight + $sidebar.height() + 24 < $scrollOffset.top + $scrollHeight) { $sidebar.stop().animate({ marginTop: $window.scrollTop() - offset.top + $menuLineHeight }) } else { $sidebar.stop().animate({ marginTop: $scrollHeight - $sidebar.height() - 24 }) } } else { $sidebar.stop().animate({ marginTop: 0 }) } } else { $sidebar.css('margin-top', 0) } }) } }

function initMessages() {
     "use strict"; $j('.message').each(function () { $j(this).find('.close').click(function (e) { e.preventDefault(); $j(this).parent().fadeOut(500) }) })
}
function totop_button(a) {
     "use strict"; var b = $j("#back_to_top"); b.removeClass("off on"); if (a === "on") { b.addClass("on") } else { b.addClass("off") }
}

function backButtonInterval() {
     "use strict"; window.setInterval(function () { var b = $j(this).scrollTop(); var c = $j(this).height(); var d; if (b > 0) { d = b + c / 2 } else { d = 1 } if (d < 1e3) { totop_button("off") } else { totop_button("on") } }, 300)
}

function backToTop() {
     "use strict"; $j(document).on('click', '#back_to_top', function (e) { e.preventDefault(); $j('body,html').animate({ scrollTop: 0 }, $j(window).scrollTop() / 3, 'swing') })
}

function fitVideo() {
     "use strict"; $j(".portfolio_images").fitVids(); $j(".video_holder").fitVids()
}

function accordionFullWidth() {
     "use strict"; if ($j('.accordion.full_screen.yes')) { var width = $j(window).width(); var margin = -(width - 1000) / 2; if (width > 1000 && $j('div.full_width').length === 0) { $j('.accordion.full_screen.yes .accordion_inner').css({ 'width': width, 'margin-left': margin, 'margin-right': margin }); $j('.accordion.full_screen.yes .accordion_inner .accordion_content').css('padding', '0px 50px 30px') } if ($j('div.full_width').length > 0) { $j('.accordion.full_screen.yes .accordion_inner .accordion_content').css('padding', '0px 50px 30px') } }
}

function topAreaLine() {
     "use strict"; if ($j('.top_area_line_holder.yes')) { var width = $j(window).width(); var margin = -(width - 1000) / 2; if (width > 1000 && $j('div.full_width').length === 0) { $j('.top_area_line_holder.yes .top_area_line').css({ 'width': width, 'margin-left': margin, 'margin-right': margin }) } }
}

function viewPort() {
     "use strict"; $j('.parallax section').waypoint(function (direction) { var $active = $j(this).next(); if (direction === "up") { $active = $active.prev() } if (!$active.length) { $active = $j(this) } var id = $active.attr("id"); $j(".link").each(function () { var i = $j(this).attr("href").replace("#", ""); if (i === id) { $j(this).addClass('active') } else { $j(this).removeClass('active') } }) }, { offset: '0%' })
}

function initParallax(speed) {
    "use strict"; if ($j('html').hasClass('touch')) {
        $j('.parallax section').each(function () {
            var $self = $j(this); var section_height = $self.data('height'); $self.height(section_height); var rate = 0.5; var bpos = (-$j(this).offset().top) * rate; $self.css({ 'background-position': 'center ' + bpos + 'px' }); $j(window).bind('scroll', function () {
                var bpos = (-$self.offset().top + $j(window).scrollTop()) * rate; $self.css({ 'background-position': 'center ' + bpos + 'px' })
            })
        })
    } else { $j('.parallax section').each(function () { var $self = $j(this); var section_height = $self.data('height'); $self.height(section_height); var rate = (section_height / $j(document).height()) * speed; var distance = $j.elementoffset($self); var bpos = -(distance * rate); $self.css({ 'background-position': 'center ' + bpos + 'px' }); $j(window).bind('scroll', function () { var distance = $j.elementoffset($self); var bpos = -(distance * rate); $self.css({ 'background-position': 'center ' + bpos + 'px' }) }) }) } return this
}
$j.elementoffset = function ($element) { "use strict"; var fold = $j(window).scrollTop(); return (fold) - $element.offset().top + 104 };

function parallaxPager() {
    "use strict"; var link_holder = $j('.link_holder_parallax'); $j('section.parallax section').each(function () { var href = $j(this).attr("id"); var title = $j(this).data("title"); var link = $j("<a />", { "href": "#" + href, "class": "link", "title": title, "html": "&nbsp;" }); link.appendTo(link_holder) }); link_holder.css('margin-top', -link_holder.height() / 2); $j('.link_holder_parallax .link:first-child').addClass('active'); $j(document).on('click', 'a.link', function () { $j('.tooltip').fadeOut(10); if ($j(this).hasClass('active')) { return false } $j('.link_holder_parallax .link').removeClass('active'); $j(this).addClass('active'); $j.scrollTo($j($j(this).attr("href")), { duration: 750, offset: { top: -1 } }); return false }); $j(".link_holder_parallax a[title]").tooltip({ position: "top left", offset: [20, -20] })
}

function selectBox() {
    "use strict"; $j('select').not('.gform_wrapper.gf_browser_chrome .ginput_complex select').sSelect(); $j('.gform_wrapper.gf_browser_chrome .ginput_complex select').sSelect({ ddMaxHeight: '300px' })
}

function initFadeDownEffect() { "use strict"; $j('.animate_list').each(function () { $j(this).appear(function () { $j(this).find("li").each(function (l) { var k = $j(this); setTimeout(function () { k.animate({ opacity: 1, top: 0 }, 1500) }, 100 * l) }) }, { accX: 0, accY: -150 }) }) } (function ($) {
    "use strict"; $.fn.countTo = function (options) {
        options = $.extend({}, $.fn.countTo.defaults, options || {}); var loops = Math.ceil(options.speed / options.refreshInterval), increment = (options.to - options.from) / loops; return $(this).each(function () {
            var _this = this, loopCount = 0, value = options.from, interval = setInterval(updateTimer, options.refreshInterval);
            function updateTimer() { value += increment; loopCount++; $(_this).html(value.toFixed(options.decimals)); if (typeof (options.onUpdate) === 'function') { options.onUpdate.call(_this, value) } if (loopCount >= loops) { clearInterval(interval); value = options.to; if (typeof (options.onComplete) === 'function') { options.onComplete.call(_this, value) } } }
        })
    }; $.fn.countTo.defaults = { from: 0, to: 100, speed: 1000, refreshInterval: 100, decimals: 0, onUpdate: null, onComplete: null, }
})(jQuery);

function initToCounter() {
    "use strict"; $j('.tocounter').each(function () {
        $j(this).appear(function () { var $max = parseFloat($j(this).text()); $j(this).countTo({ from: 0, to: $max, speed: 1500, refreshInterval: 50 }) }, { accX: 0, accY: -150 })
    })
} function placeholderReplace() { "use strict"; $j('[placeholder]').focus(function () { var input = $j(this); if (input.val() === input.attr('placeholder')) { if (this.originalType) { this.type = this.originalType; delete this.originalType } input.val(''); input.removeClass('placeholder') } }).blur(function () { var input = $j(this); if (input.val() === '') { if (this.type === 'password') { this.originalType = this.type; this.type = 'text' } input.addClass('placeholder'); input.val(input.attr('placeholder')) } }).blur(); $j('[placeholder]').parents('form').submit(function () { $j(this).find('[placeholder]').each(function () { var input = $j(this); if (input.val() === input.attr('placeholder')) { input.val('') } }) }) }

function addPlaceholderSearchWidget() {
    "use strict"; $j('.header_right_widget #searchform input:text').each(function (i, el) { if (!el.value || el.value == '') { el.placeholder = 'Search' } })
}
function prettyPhoto() {
    $j('a[data-rel]').each(function () { $j(this).attr('rel', $j(this).data('rel')) }); $j("a[rel^='prettyPhoto']").prettyPhoto({ animation_speed: 'fast', slideshow: false, autoplay_slideshow: false, opacity: 0.80, show_title: true, allow_resize: true, default_width: 500, default_height: 344, counter_separator_label: '/', theme: 'pp_default', hideflash: false, wmode: 'opaque', autoplay: true, modal: false, overlay_gallery: false, keyboard_shortcuts: true, deeplinking: false, social_tools: false })
}

function checkLogOnSmallestSize() {
    "use strict"; if ($j(window).width() < 768) { if (logo_height >= 80) { $j('.logo a').height(70); $j('.logo').css('padding', '5px 0px 5px 0px') } else { var padding = (80 - logo_height) / 2; $j('.logo').css('padding', padding + 'px 0px') } } else { $j('.logo').css('padding', '0px') }
}

function loadMore() {
    "use strict"; var i = 1; $j('.load_more a').on('click', function (e) {
        e.preventDefault(); resetFilter(); var link = $j(this).attr('href'); var $content = '.projects_holder'; var $nav_wrap = '.portfolio_paging'; var $anchor = '.portfolio_paging .load_more a'; var $next_href = $j($anchor).attr('href'); var filler_num = $j('.projects_holder .filler').length; $j.get(link + '', function (data) {
            $j('.projects_holder .filler').slice(-filler_num).remove(); var $new_content = $j($content, data).wrapInner('').html(); $next_href = $j($anchor, data).attr('href'); $j('article.mix:last').after($new_content); var min_height = $j('article.mix:first').height(); $j('article.mix').css('min-height', min_height); $j('.projects_holder').mixitup('remix', 'all'); prettyPhoto(); $j('.projects_holder > .mix ').each(function () {
                $j(this).hoverdir()
            }); if ($j('.load_more').attr('rel') > i) { $j('.load_more a').attr('href', $next_href) } else { $j('.load_more').remove() } $j('.projects_holder .portfolio_paging:last').remove(); $j('article.mix').css('min-height', 0)
        }); i++
    })
}

function initAccordionContentLink() {
    "use strict"; $j('.accordion > .accordion_inner > .accordion_content a').click(function (event) { if ($j(this).attr('target') === '_blank') { window.open($j(this).attr('href'), '_blank') } else { window.open($j(this).attr('href'), '_self') } return false });
    $j('.accordion_holder > div.accordion_content > div.accordion_content_inner a').click(function (event) { if ($j(this).attr('target') === '_blank') { window.open($j(this).attr('href'), '_blank') } else { window.open($j(this).attr('href'), '_self') } return false })
}