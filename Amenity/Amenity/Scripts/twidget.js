// JScript source code

new TWTR.Widget(
		{
		    version: 2,
		    type: 'search',
		    search: 'Fingal Dublin',
		    interval: 3000,
		    title: 'Who\'s Tweeting',
		    subject: 'About Fingal',
		    width: 250,
		    height: 300,
		    theme:
			{
			    shell:
				{
				    background: '#8ec1da',
				    color: '#ffffff'
				},
			    tweets:
				{
				    background: '#ffffff',
				    color: '#444444',
				    links: '#1985b5'
				}
			},
		    features:
			{
			    scrollbar: false,
			    loop: true,
			    live: true,
			    behavior: 'default'
			}
		}
		).render().start();